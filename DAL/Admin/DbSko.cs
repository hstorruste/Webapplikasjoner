using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Nettbutikk;
using DAL.Nettbutikk;

namespace DAL.Admin
{
    public class DbSko : IDbSko
    {
        public Skoen lagreSko(Skoen innsko)
        {
            using (var db = new NettbutikkContext())
            {
                try
                {
                    var nySko = new Sko {
                        Navn = innsko.navn,
                        Farge = innsko.farge,
                        Beskrivelse = innsko.beskrivelse,
                        
                    };
                    var lagretSko = db.Sko.Add(nySko);
                    //Sjekk om merke eksisterer og legger til merke.
                    var eksistererMerke = db.Merker.SingleOrDefault(m => m.Navn == innsko.merke);
                    if(eksistererMerke == null)
                    {
                        var lagtTilMerke = db.Merker.Add(new Merker { Navn = innsko.merke });
                        lagretSko.Merke = lagtTilMerke;
                    }
                    else
                    {
                        lagretSko.Merke = eksistererMerke;
                    }

                    //Sjekk om kategori eksisterer og legger til kategori.
                    var eksistererKategori = db.Kategorier.SingleOrDefault(k => k.Navn == innsko.kategori);
                    if(eksistererKategori == null)
                    {
                        var lagtTilKategori = db.Kategorier.Add(new Kategorier { Navn = innsko.kategori });
                        lagretSko.Kategori = lagtTilKategori;
                    }
                    else
                    {
                        lagretSko.Kategori = eksistererKategori;
                    }

                    //Sjekk om ForHvem eksisterer og legger til ForHvem.
                    var eksistererFor = db.For.SingleOrDefault(f => f.Navn == innsko.forHvem);
                    if(eksistererFor == null)
                    {
                        var lagtTilFor = db.For.Add(new For { Navn = innsko.forHvem });
                        lagretSko.ForHvem = lagtTilFor;
                    }
                    else
                    {
                        lagretSko.ForHvem = eksistererFor;
                    }

                    //Legger til pris
                    db.Priser.Add(new Priser { Pris = innsko.pris, Sko = lagretSko, Dato = DateTime.Now });

                    db.SaveChanges();
                    var utSko = new Skoen
                    {
                        skoId = lagretSko.SkoId,
                        navn = lagretSko.Navn,
                        merke = lagretSko.Merke.Navn,
                        farge = lagretSko.Farge,
                        kategori = lagretSko.Kategori.Navn,
                        forHvem = lagretSko.ForHvem.Navn,
                        beskrivelse = lagretSko.Beskrivelse,
                        pris = lagretSko.Pris.OrderByDescending( p => p.Dato).FirstOrDefault().Pris
                    };
                    return utSko;

                }
                catch (Exception feil)
                {
                    DAL.ErrorHandler.logError(feil);
                    return null;
                }
            }
        }

        public List<Skoen> getAktuelleSko()
        {
            using (var db = new NettbutikkContext())
            {
                try
                {
                    var liste = db.Sko.Where(s => !s.Slettet).Select(s => new Skoen
                    {
                        skoId = s.SkoId,
                        navn = s.Navn,
                        merke = s.Merke.Navn,
                        kategori = s.Kategori.Navn,
                        forHvem = s.ForHvem.Navn,
                        beskrivelse = s.Beskrivelse,
                        farge = s.Farge,
                        pris = s.Pris.OrderByDescending(p => p.Dato).FirstOrDefault().Pris

                    }).ToList();

                    return liste;
                }
                catch (Exception feil)
                {
                    DAL.ErrorHandler.logError(feil);
                    return null;
                }
            }
        }

        public List<Pris> getPrishistorikk(int skoId)
        {
            using (var db = new NettbutikkContext())
            {
                try
                {
                    var priser = db.Priser.Where(p => p.SkoId == skoId)
                        .OrderByDescending(p => p.Dato).Select(p => new Pris
                        {
                            skoId = p.SkoId,
                            skoNavn = p.Sko.Navn,
                            dato = p.Dato,
                            pris = p.Pris

                        }).ToList();

                    return priser;
                }
                catch (Exception feil)
                {
                    DAL.ErrorHandler.logError(feil);
                    return null;
                }
            }
        }

        public Skoen getSko(int id)
        {
            using (var db = new NettbutikkContext())
            {
                try
                {
                    var enSko = db.Sko.SingleOrDefault(s => s.SkoId == id);
                    if (enSko != null)
                    {
                        Skoen hentetSko = new Skoen()
                        {
                            skoId = enSko.SkoId,
                            navn = enSko.Navn,
                            kategori = enSko.Kategori.Navn,
                            merke = enSko.Merke.Navn,
                            forHvem = enSko.ForHvem.Navn,
                            pris = enSko.Pris.OrderByDescending(p => p.Dato).FirstOrDefault().Pris,
                            farge = enSko.Farge,
                            beskrivelse = enSko.Beskrivelse,
                            storlekar = enSko.Storlekar.Select(t => new Storlek()
                            {
                                storlekId = t.StorlekId,
                                storlek = t.Storlek,
                                antall = t.Antall
                            }).ToList(),
                            bilder = enSko.Bilder.Select(b => new Bilde()
                            {
                                bildeId = b.BildeId,
                                bildeUrl = b.BildeUrl
                            }).ToList(),
                            slettet = enSko.Slettet
                            
                        };

                        return hentetSko;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception feil)
                {
                    DAL.ErrorHandler.logError(feil);
                    return null;
                }
            }
        }

        public List<Skoen> getSlettedeSko()
        {
            using (var db = new NettbutikkContext())
            {
                try
                {
                    var liste = db.Sko.Where(s => s.Slettet).Select(s => new Skoen
                    {
                        skoId = s.SkoId,
                        navn = s.Navn,
                        merke = s.Merke.Navn,
                        kategori = s.Kategori.Navn,
                        forHvem = s.ForHvem.Navn,
                        beskrivelse = s.Beskrivelse,
                        farge = s.Farge,
                        pris = s.Pris.OrderByDescending(p => p.Dato).FirstOrDefault().Pris

                    }).ToList();
                    return liste;
                }
                catch (Exception feil)
                {
                    DAL.ErrorHandler.logError(feil);
                    return null;
                }
            }
        }

        public Skoen gjenopprett(int id)
        {
            using (var db = new NettbutikkContext())
            {
                try
                {
                    var enSko = db.Sko.Find(id);
                    if (enSko == null)
                        return null;

                    enSko.Slettet = false;
                    var gjenopprettet = new Skoen
                    {
                        skoId = enSko.SkoId,
                        navn = enSko.Navn,
                        kategori = enSko.Kategori.Navn,
                        merke = enSko.Merke.Navn,
                        forHvem = enSko.ForHvem.Navn,
                        pris = enSko.Pris.OrderByDescending(p => p.Dato).FirstOrDefault().Pris,
                        farge = enSko.Farge,
                        beskrivelse = enSko.Beskrivelse,
                        storlekar = enSko.Storlekar.Select(t => new Storlek()
                        {
                            storlekId = t.StorlekId,
                            storlek = t.Storlek,
                            antall = t.Antall
                        }).ToList(),
                        bilder = enSko.Bilder.Select(b => new Bilde()
                        {
                            bildeId = b.BildeId,
                            bildeUrl = b.BildeUrl
                        }).ToList()
                    };
                    db.SaveChanges();

                    return gjenopprettet;
                }
                catch (Exception feil)
                {
                    DAL.ErrorHandler.logError(feil);
                    return null;
                }
            }
        }

        public Skoen slett(int id)
        {
            using(var db = new NettbutikkContext())
            {
                try
                {
                    var enSko = db.Sko.Find(id);
                    if (enSko == null)
                        return null;

                    enSko.Slettet = true;
                    var slettet =  new Skoen {
                        skoId = enSko.SkoId,
                        navn = enSko.Navn,
                        kategori = enSko.Kategori.Navn,
                        merke = enSko.Merke.Navn,
                        forHvem = enSko.ForHvem.Navn,
                        pris = enSko.Pris.OrderByDescending(p => p.Dato).FirstOrDefault().Pris,
                        farge = enSko.Farge,
                        beskrivelse = enSko.Beskrivelse,
                        storlekar = enSko.Storlekar.Select(t => new Storlek()
                        {
                            storlekId = t.StorlekId,
                            storlek = t.Storlek,
                            antall = t.Antall
                        }).ToList(),
                        bilder = enSko.Bilder.Select(b => new Bilde()
                        {
                            bildeId = b.BildeId,
                            bildeUrl = b.BildeUrl
                        }).ToList()
                    };
                    db.SaveChanges();

                    return slettet;
                }
                catch(Exception feil)
                {
                    DAL.ErrorHandler.logError(feil);
                    return null;
                }
            }
        }

        public Storlek leggTilStorlek(int skoId, Storlek innStr)
        {
            using (var db = new NettbutikkContext())
            {
                try
                {
                    var nyStr = new Storlekar
                    {
                        Storlek = innStr.storlek,
                        Sko = db.Sko.Find(skoId),
                        Antall = innStr.antall
                    };
                    var lagretStr = db.Storlekar.Add(nyStr);
                    db.SaveChanges();
                    var utStr = new Storlek
                    {
                        storlekId = lagretStr.StorlekId,
                        storlek = lagretStr.Storlek,
                        antall = lagretStr.Antall
                    };
                    return utStr;
                }
                catch (Exception feil)
                {
                    DAL.ErrorHandler.logError(feil);
                    return null;
                }
            }
        }

        public Bilde leggTilBilde(int skoId, Bilde innBilde)
        {
            using (var db = new NettbutikkContext())
            {
                try
                {
                    var nyttBilde = new Bilder
                    {
                        BildeUrl = innBilde.bildeUrl,
                        Sko = db.Sko.Find(skoId)
                    };
                    var lagretBilde = db.Bilder.Add(nyttBilde);
                    db.SaveChanges();
                    var utBilde = new Bilde
                    {
                        bildeId = lagretBilde.BildeId,
                        bildeUrl = lagretBilde.BildeUrl
                    };
                    return utBilde;
                }
                catch (Exception feil)
                {
                    DAL.ErrorHandler.logError(feil);
                    return null;
                }
            }
        }

        public Storlek slettStorlek(int id)
        {
            using (var db = new NettbutikkContext())
            {
                try
                {
                    var slettet = db.Storlekar.Remove(db.Storlekar.Find(id));
                    db.SaveChanges();
                    return new Storlek() { storlekId = slettet.StorlekId, storlek = slettet.Storlek };
                }
                catch (Exception feil)
                {
                    DAL.ErrorHandler.logError(feil);
                    return null;
                }
            }
        }

        public Bilde slettBilde(int id)
        {
            using (var db = new NettbutikkContext())
            {
                try
                {
                    var slettet = db.Bilder.Remove(db.Bilder.Find(id));
                    db.SaveChanges();
                    return new Bilde() { bildeId = slettet.BildeId, bildeUrl = slettet.BildeUrl };
                }
                catch (Exception feil)
                {
                    DAL.ErrorHandler.logError(feil);
                    return null;
                }
            }
        }
    }
}
