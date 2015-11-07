using Model.Nettbutikk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL.Nettbutikk
{
    public class DbKunder
    {
        public static KundeModell getKunde(string epost)
        {
            using (var db = new NettbutikkContext())
            {
                Kunder temp = db.Kunder.Include("Passorden").FirstOrDefault(k => k.Epost == epost);
                return new KundeModell() {
                    id = temp.Id,
                    fornavn = temp.Fornavn,
                    etternavn = temp.Etternavn,
                    adresse = temp.Adresse,
                    postnr = temp.Postnr,
                    poststed = temp.Poststeder.Poststed,
                    epost = temp.Epost,
                    passordId = temp.Passorden.PassordId
                };
            }
        }

        public static int getKundePassord(int innPassordId)
        {
            using (var db = new NettbutikkContext())
            {
                return db.Passorden.FirstOrDefault(p => p.PassordId == innPassordId).PassordId;
            }
        }

        public static bool registrerKunde(RegistrerKundeModell innKunde)
        {
            using (var db = new NettbutikkContext())
            {
                try
                {
                    //Test för att göra Email unikt. Vet inte om detta är det bästa sättet.
                    var finnesKunde = db.Kunder.FirstOrDefault(k => k.Epost == innKunde.epost);
                    if (finnesKunde == null)
                    {
                        var nyKunde = new Kunder();
                        nyKunde.Fornavn = innKunde.fornavn;
                        nyKunde.Etternavn = innKunde.etternavn;
                        nyKunde.Adresse = innKunde.adresse;
                        nyKunde.Postnr = innKunde.postnr;
                        var eksisterandePostnr = db.Poststeder.Find(innKunde.postnr);
                        if (eksisterandePostnr == null)
                        {
                            var nyttPoststed = new Poststeder()
                            {
                                Postnr = innKunde.postnr,
                                Poststed = innKunde.poststed
                            };
                            nyKunde.Poststeder = nyttPoststed;
                        }
                        nyKunde.Epost = innKunde.epost;
                        byte[] passordDb = lagHash(innKunde.passord);
                        var passord = new Passorden()
                        {
                            Passord = passordDb,
                            Kunde = nyKunde,
                        };
                        nyKunde.Passorden = passord;
                        db.Kunder.Add(nyKunde);
                        db.SaveChanges();

                        return true;
                    }
                    else
                    {  
                        return false;
                    }
                }
                catch (Exception feil)
                {
                    ErrorHandler.logError(feil);
                    return false;
                }
            }
        }

        public static RedigerKundeModell hentEnKunde(int id)
        {
            using (var db = new NettbutikkContext())
            {
                var enDbKunde = db.Kunder.Find(id);

                if (enDbKunde == null)
                    return null;
                else
                {
                    var utKunde = new RedigerKundeModell()
                    {
                        id = enDbKunde.Id,
                        fornavn = enDbKunde.Fornavn,
                        etternavn = enDbKunde.Etternavn,
                        adresse = enDbKunde.Adresse,
                        postnr = enDbKunde.Postnr,
                        poststed = enDbKunde.Poststeder.Poststed,
                        epost = enDbKunde.Epost
                    };
                    return utKunde;
                }
            }
        }

        public static bool redigerKunde(RedigerKundeModell innKunde)
        {
            bool sparadKunde = false;

            using (var db = new NettbutikkContext())
            {
                try
                {
                    var upKunde = db.Kunder.Where(k => k.Id == innKunde.id).SingleOrDefault();
                    var finnesKunde = db.Kunder.FirstOrDefault(k => k.Epost == innKunde.epost);

                    if (finnesKunde.Id == innKunde.id)
                    {
                        finnesKunde = null;
                    }

                    if (finnesKunde == null && upKunde != null)
                    {
                        upKunde.Fornavn = innKunde.fornavn;
                        upKunde.Etternavn = innKunde.etternavn;
                        upKunde.Adresse = innKunde.adresse;
                        upKunde.Postnr = innKunde.postnr;
                        var eksisterandePostnr = db.Poststeder.Find(innKunde.postnr);
                        if (eksisterandePostnr == null)
                        {
                            var nyttPoststed = new Poststeder()
                            {
                                Postnr = innKunde.postnr,
                                Poststed = innKunde.poststed
                            };
                            upKunde.Poststeder = nyttPoststed;
                        }
                        upKunde.Epost = innKunde.epost;
                        db.SaveChanges();

                        sparadKunde = true;
                    }
                }
                catch (Exception feil)
                {
                    ErrorHandler.logError(feil);
                    sparadKunde = false;
                }
                return sparadKunde;
            }
        }

        public static RedigerKundePassordModell hentEnKundePassord(int passordId)
        {
            using (var db = new NettbutikkContext())
            {
                var enDbKundePassord = db.Passorden.Find(passordId);

                if (enDbKundePassord == null)
                    return null;
                else
                {
                    var utKundePassord = new RedigerKundePassordModell()
                    {
                        passordId = enDbKundePassord.PassordId
                    };
                    return utKundePassord;
                }
            }
        }
        public static bool redigerKundePassord(RedigerKundePassordModell innPassord)
        {
            bool sparadPassord = false;

            using (var db = new NettbutikkContext())
            {
                try
                {
                    var upPassord = db.Passorden.Where(p => p.PassordId == innPassord.passordId).SingleOrDefault();

                    if (upPassord != null)
                    {
                        byte[] gammeltpassordDb = lagHash(innPassord.gammeltPassord);
                        byte[] passordDb = lagHash(innPassord.nyttPassord);
                        //Sjekker om det er skrevet riktig gammelt passord.
                        if (!gammeltpassordDb.SequenceEqual(upPassord.Passord))
                        {
                            return false;
                        }

                        upPassord.Passord = passordDb;
                        
                        db.SaveChanges();

                        sparadPassord = true;
                    }
                }
                catch(Exception feil)
                {
                    ErrorHandler.logError(feil);
                    sparadPassord = false;
                }
                return sparadPassord;
            }
        }

        public static byte[] lagHash(string innPassord)
        {
            byte[] innData, utData;
            var algoritme = System.Security.Cryptography.SHA256.Create();
            innData = System.Text.Encoding.ASCII.GetBytes(innPassord);
            utData = algoritme.ComputeHash(innData);
            return utData;
        }

        public static bool Kunde_i_DB(LoggInnModell innKunde)
        {
            using (var db = new NettbutikkContext())
            {
                byte[] passordDb = lagHash(innKunde.passord);
                Kunder funnetKunde = db.Kunder.FirstOrDefault
                    (k => k.Passorden.Passord == passordDb && k.Epost == innKunde.Epost);
                if (funnetKunde == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public static Ordre getOrdre(int ordreId)
        {
            using (var db = new NettbutikkContext())
            {
                try
                {
                    Ordrer enOrdre = db.Ordrer.Include("OrdreDetaljer.Sko.Merke").Include("OrdreDetaljer.Sko.Bilder").Include("Kunder.Poststeder")
                        .SingleOrDefault(o => o.OrdreId == ordreId);
                    return new Ordre()
                    {
                        ordreId = enOrdre.OrdreId,
                        ordreDato = enOrdre.OrdreDato,
                        kundeId = enOrdre.KundeId,
                        kundeNavn = enOrdre.Kunder.Fornavn + " " + enOrdre.Kunder.Etternavn,
                        adresse = enOrdre.Kunder.Adresse,
                        postnr = enOrdre.Kunder.Postnr,
                        poststed = enOrdre.Kunder.Poststeder.Poststed,
                        varer = enOrdre.OrdreDetaljer.Select(d => new HandlevognVare
                        {
                            skoId = d.Sko.SkoId,
                            skoNavn = d.Sko.Navn,
                            merke = d.Sko.Merke.Navn,
                            farge = d.Sko.Farge,
                            storlek = d.Storlek,
                            pris = d.Pris,
                            bildeUrl = d.Sko.Bilder.Where(b => b.BildeUrl.Contains("/Medium/")).FirstOrDefault().BildeUrl,
                        }).ToList(),
                        totalBelop = enOrdre.TotalBelop
                    };
                }
                catch (Exception feil)
                {
                    ErrorHandler.logError(feil);
                    return null;
                }
            }
        }

        public static bool arkiverOrdre(string sessionId, int kundeId)
        {
            var nyOrdre = DbHandlevogn.lagOrdre(sessionId, kundeId);
            using (var db = new NettbutikkContext())
            {
                try
                {
                    //Må sette relasjonene i ordrer og ordredetaljer til entiteter i databasen ellers forsøkes sko og kunde å lagres på nytt i databasen.
                    foreach (var detalj in nyOrdre.OrdreDetaljer)
                    {
                        detalj.Sko = db.Sko.Find(detalj.SkoId);
                    }
                    nyOrdre.Kunder = db.Kunder.Find(nyOrdre.KundeId);

                    db.Ordrer.Add(nyOrdre);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception feil)
                {
                    ErrorHandler.logError(feil);
                    return false;
                }
            }
        }

        public static List<Ordre> finnAlleOrdre(int KundeId)
        {
            using (var db = new NettbutikkContext())
            {
                try
                {
                    List<Ordre> alleOrdre = db.Ordrer.Where(o => o.KundeId == KundeId).Select( o => new Ordre()
                    {
                        ordreId = o.OrdreId,
                        ordreDato = o.OrdreDato,
                        kundeId = o.KundeId,
                        kundeNavn = o.Kunder.Fornavn + " " + o.Kunder.Etternavn,
                        adresse = o.Kunder.Adresse,
                        postnr = o.Kunder.Postnr,
                        poststed = o.Kunder.Poststeder.Poststed,
                        varer = o.OrdreDetaljer.Select(d => new HandlevognVare
                        {
                            skoId = d.Sko.SkoId,
                            skoNavn = d.Sko.Navn,
                            merke = d.Sko.Merke.Navn,
                            farge = d.Sko.Farge,
                            storlek = d.Storlek,
                            pris = d.Pris,
                            bildeUrl = d.Sko.Bilder.Where(b => b.BildeUrl.Contains("/Medium/")).FirstOrDefault().BildeUrl,
                        }).ToList(),
                        totalBelop = o.TotalBelop
                    }).ToList();
                    return alleOrdre;
                }
                catch (Exception feil)
                {
                    ErrorHandler.logError(feil);
                    return null;
                }
            }
        }

        public static Ordre finnSisteOrdre(int KundeId)
        {
            using (var db = new NettbutikkContext())
            {
                try
                {
                    Ordrer sisteOrdre = db.Ordrer.Include("OrdreDetaljer.Sko.Merke").Include("OrdreDetaljer.Sko.Bilder").Include("Kunder.Poststeder")
                        .Where(o => o.KundeId == KundeId).OrderByDescending(o => o.OrdreDato).FirstOrDefault();
                    var ordre = new Ordre()
                    {
                        ordreId = sisteOrdre.OrdreId,
                        ordreDato = sisteOrdre.OrdreDato,
                        kundeId = sisteOrdre.KundeId,
                        kundeNavn = sisteOrdre.Kunder.Fornavn + " " + sisteOrdre.Kunder.Etternavn,
                        adresse = sisteOrdre.Kunder.Adresse,
                        postnr = sisteOrdre.Kunder.Postnr,
                        poststed = sisteOrdre.Kunder.Poststeder.Poststed,
                        varer = sisteOrdre.OrdreDetaljer.Select(d => new HandlevognVare
                        {
                            skoId = d.Sko.SkoId,
                            skoNavn = d.Sko.Navn,
                            merke = d.Sko.Merke.Navn,
                            farge = d.Sko.Farge,
                            storlek = d.Storlek,
                            pris = d.Pris,
                            bildeUrl = d.Sko.Bilder.Where(b => b.BildeUrl.Contains("/Medium/")).FirstOrDefault().BildeUrl,
                        }).ToList(),
                        totalBelop = sisteOrdre.TotalBelop
                    };
                    return ordre;
                }
                catch (Exception feil)
                {
                    ErrorHandler.logError(feil);
                    return null;
                }
            }
        }
    }
}