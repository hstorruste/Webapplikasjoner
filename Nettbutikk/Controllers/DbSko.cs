using Nettbutikk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nettbutikk.Controllers
{
    public class DbSko
    {
        public static List<Skoen> hentAlleSko()
        {
            using (var db = new NettbutikkContext())
            {
                List<Skoen> alleSko = db.Sko.Select(s => new Skoen()
                {
                    navn = s.Navn,
                    kategori = s.Kategori.Navn,
                    merke = s.Merke.Navn,
                    forHvem = s.ForHvem.Navn,
                    pris = s.Pris,
                    farge = s.Farge,
                    beskrivelse = s.Beskrivelse,
                    storlekar = s.Storlekar,
                    bilder = s.Bilder

                }).ToList();

                return alleSko;
            }
        }

        public static Skoen hentEnSko(int skoId)
        {
            using (var db = new NettbutikkContext())
            {
                Sko enSko = db.Sko.SingleOrDefault(s => s.SkoId == skoId);
                if (enSko != null)
                {
                    Skoen hentetSko = new Skoen()
                    {
                        navn = enSko.Navn,
                        kategori = enSko.Kategori.Navn,
                        merke = enSko.Merke.Navn,
                        forHvem = enSko.ForHvem.Navn,
                        pris = enSko.Pris,
                        farge = enSko.Farge,
                        beskrivelse = enSko.Beskrivelse,
                        storlekar = enSko.Storlekar,
                        bilder = enSko.Bilder

                    };

                    return hentetSko;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}