using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nettbutikk.Model;
using Nettbutikk.DAL;

namespace Admin.DAL
{
    public class DbAttributter : IDbAttributter
    {
        public ForHvem addFor(string forNavn)
        {
            var ny = new For
            {
                Navn = forNavn
            };
            using (var db = new NettbutikkContext())
            {
                try
                {
                    db.For.Add(ny);
                    db.SaveChanges();
                    var lagret = db.For.SingleOrDefault(f => f.Navn == forNavn);
                    return new ForHvem { forId = lagret.ForId, navn = lagret.Navn };
                }
                catch
                {
                    return null;
                }
            }
        }

        public Kategori addKategori(string kategoriNavn)
        {

            var ny = new Kategorier
            {
                Navn = kategoriNavn
            };
            using (var db = new NettbutikkContext())
            {
                try
                {
                    db.Kategorier.Add(ny);
                    db.SaveChanges();
                    var lagret = db.Kategorier.SingleOrDefault(k => k.Navn == kategoriNavn);
                    return new Kategori {  kategoriId = lagret.KategoriId, navn = lagret.Navn };
                }
                catch
                {
                    return null;
                }
            }
        }

        public Merke addMerke(string merkeNavn)
        {

            var ny = new Merker
            {
                Navn = merkeNavn
            };
            using (var db = new NettbutikkContext())
            {
                try
                {
                    db.Merker.Add(ny);
                    db.SaveChanges();
                    var lagret = db.Merker.SingleOrDefault(f => f.Navn == merkeNavn);
                    return new Merke { merkeId = lagret.MerkerId, navn = lagret.Navn };
                }
                catch
                {
                    return null;
                }
            }
        }

        public ForHvem deleteFor(int id)
        {
            throw new NotImplementedException();
        }

        public Merke deleteKategori(int id)
        {
            throw new NotImplementedException();
        }

        public Kategori deleteMerke(int id)
        {
            throw new NotImplementedException();
        }

        public List<ForHvem> getFor()
        {
            throw new NotImplementedException();
        }

        public ForHvem getFor(int id)
        {
            throw new NotImplementedException();
        }

        public Kategori getKategori(int id)
        {
            throw new NotImplementedException();
        }

        public List<Kategori> getKategorier()
        {
            throw new NotImplementedException();
        }

        public List<Merke> getMerke()
        {
            throw new NotImplementedException();
        }

        public Merke getMerke(int id)
        {
            throw new NotImplementedException();
        }

        public ForHvem updateFor(ForHvem forhvem)
        {
            throw new NotImplementedException();
        }

        public Kategori updateKategori(Kategori kategori)
        {
            throw new NotImplementedException();
        }

        public Merke updateMerke(Merke merke)
        {
            throw new NotImplementedException();
        }
    }
}
