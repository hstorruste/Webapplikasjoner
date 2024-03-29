﻿using Model.Nettbutikk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL.Nettbutikk
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
                        pris = s.Pris.OrderByDescending(p => p.Dato).FirstOrDefault().Pris,
                        farge = s.Farge,
                        beskrivelse = s.Beskrivelse,
                        storlekar = s.Storlekar.Select(t => new Storlek (){
                            storlekId = t.StorlekId,
                            storlek = t.Storlek,
                            antall = t.Antall
                        }).ToList(),
                        bilder = s.Bilder.Select(b => new Bilde() {
                            bildeId = b.BildeId,
                            bildeUrl = b.BildeUrl
                        }).ToList()

                    }).ToList();


                    return alleSko;
                }
                catch (Exception feil)
                {
                    ErrorHandler.logError(feil);
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
                        pris = s.Pris.OrderByDescending(p => p.Dato).FirstOrDefault().Pris,
                        farge = s.Farge,
                        beskrivelse = s.Beskrivelse,
                        storlekar = s.Storlekar.Select(t => new Storlek()
                        {
                            storlekId = t.StorlekId,
                            storlek = t.Storlek,
                            antall = t.Antall
                        }).ToList(),
                        bilder = s.Bilder.Select(b => new Bilde()
                        {
                            bildeId = b.BildeId,
                            bildeUrl = b.BildeUrl
                        }).ToList()

                    }).ToList();


                    return alleSko;
                }
                catch (Exception feil)
                {
                    ErrorHandler.logError(feil);
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
                        pris = s.Pris.OrderByDescending(p => p.Dato).FirstOrDefault().Pris,
                        farge = s.Farge,
                        beskrivelse = s.Beskrivelse,
                        storlekar = s.Storlekar.Select(t => new Storlek()
                        {
                            storlekId = t.StorlekId,
                            storlek = t.Storlek,
                            antall = t.Antall
                        }).ToList(),
                        bilder = s.Bilder.Select(b => new Bilde()
                        {
                            bildeId = b.BildeId,
                            bildeUrl = b.BildeUrl
                        }).ToList()

                    }).ToList();


                    return alleSko;
                }
                catch (Exception feil)
                {
                    ErrorHandler.logError(feil);
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
                    ErrorHandler.logError(feil);
                    return null;
                }
            }
        }

        public static List<ForHvem> hentAlleForHvem()
        {
            using (var db = new NettbutikkContext())
            {
                try
                {
                    List<ForHvem> forHvem= db.For.Select( f => new ForHvem() {
                        forId = f.ForId,
                        navn = f.Navn
                    }).ToList();

                    return forHvem;
                }
                catch (Exception feil)
                {
                    ErrorHandler.logError(feil);
                    return null;
                }
            }
        }

        public static List<Kategori> hentAlleKategorierForHvem(int forHvemId)
        {
            using (var db = new NettbutikkContext())
            {
                try
                {
                    List<Kategori> kategorier = db.Sko.Where(s => s.ForId == forHvemId)
                        .Select( s => s.Kategori).Distinct().Select( k => new Kategori() {
                            kategoriId = k.KategoriId,
                            navn = k.Navn
                        }).ToList();

                    return kategorier;
                }
                catch (Exception feil)
                {
                    ErrorHandler.logError(feil);
                    return null;
                }
            }
        }

        public static ForHvem getFor(int forId)
        {
            using (var db = new NettbutikkContext())
            {
                try
                {
                    For temp = db.For.Find(forId);
                    ForHvem forHvem = new ForHvem()
                    {
                        forId = temp.ForId,
                        navn = temp.Navn
                    };

                    return forHvem;
                }
                catch (Exception feil)
                {
                    ErrorHandler.logError(feil);
                    return null;
                }
            }
        }
        public static Kategori getKategori(int kategoriId)
        {
            using (var db = new NettbutikkContext())
            {
                try
                {
                    Kategorier temp = db.Kategorier.Find(kategoriId);
                    Kategori kategori = new Kategori()
                    {
                        kategoriId = temp.KategoriId,
                        navn = temp.Navn
                    };
                    return kategori;
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