using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nettbutikk.Model;
using Nettbutikk.DAL;

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
                    return null;
                }
            }
        }
    }
}
