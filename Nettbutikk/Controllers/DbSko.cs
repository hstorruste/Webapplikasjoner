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
                try
                {
                    List<Skoen> alleSko = db.Sko.Select(s => new Skoen()
                    {
                        skoId = s.SkoId,
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
                catch (Exception feil)
                {
                    return null;
                }
            }
        }

        public static List<Skoen> hentAlleSkoFor(int forHvemId)
        {
            using (var db = new NettbutikkContext())
            {
                try
                {
                    List<Skoen> alleSko = db.Sko.Where( s => s.ForId == forHvemId).Distinct().Select(s => new Skoen()
                    {
                        skoId = s.SkoId,
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
                catch (Exception feil)
                {
                    return null;
                }
            }
        }

        public static List<Skoen> hentAlleSkoFor(int forHvemId, int kategoriId)
        {
            using (var db = new NettbutikkContext())
            {
                try
                {
                    List<Skoen> alleSko = db.Sko.Where(s => s.ForId == forHvemId && s.KategoriId == kategoriId).Distinct().Select(s => new Skoen()
                    {
                        skoId = s.SkoId,
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
                catch (Exception feil)
                {
                    return null;
                }
            }
        }
        public static Skoen hentEnSko(int skoId)
        {
            using (var db = new NettbutikkContext())
            {
                try
                {
                    Sko enSko = db.Sko.SingleOrDefault(s => s.SkoId == skoId);
                    if (enSko != null)
                    {
                        Skoen hentetSko = new Skoen()
                        {
                            skoId = enSko.SkoId,
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
                catch (Exception feil)
                {
                    return null;
                }
            }
        }

        public static List<For> hentAlleForHvem()
        {
            using (var db = new NettbutikkContext())
            {
                try
                {
                    List<For> forHvem= db.For.ToList();

                    return forHvem;
                }
                catch (Exception feil)
                {
                    return null;
                }
            }
        }

        public static List<Kategorier> hentAlleKategorierForHvem(int forHvemId)
        {
            using (var db = new NettbutikkContext())
            {
                try
                {
                    List<Kategorier> kategorier = db.Sko.Where(s => s.ForId == forHvemId)
                        .Select( s => s.Kategori).Distinct().ToList();

                    return kategorier;
                }
                catch (Exception feil)
                {
                    return null;
                }
            }
        }

        public static For getFor(int forId)
        {
            using (var db = new NettbutikkContext())
            {
                try
                {
                    For forHvem = db.For.Find(forId);

                    return forHvem;
                }
                catch (Exception feil)
                {
                    return null;
                }
            }
        }
        public static Kategorier getKategori(int kategoriId)
        {
            using (var db = new NettbutikkContext())
            {
                try
                {
                    Kategorier kategori = db.Kategorier.Find(kategoriId);

                    return kategori;
                }
                catch (Exception feil)
                {
                    return null;
                }
            }
        }
    }
}