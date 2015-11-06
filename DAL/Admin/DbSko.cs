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
                            }).ToList()

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
    }
}
