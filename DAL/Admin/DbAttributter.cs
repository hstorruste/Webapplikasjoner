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
            using(var db = new NettbutikkContext())
            {
                try
                {
                    var slettet = db.For.Remove(db.For.Find(id));
                    return new ForHvem() { forId = slettet.ForId, navn = slettet.Navn};
                }
                catch(Exception feil)
                {
                    return null;
                }
            }
        }

        public Kategori deleteKategori(int id)
        {
            using (var db = new NettbutikkContext())
            {
                try
                {
                    var slettet = db.Kategorier.Remove(db.Kategorier.Find(id));
                    return new Kategori() { kategoriId = slettet.KategoriId, navn = slettet.Navn };
                }
                catch (Exception feil)
                {
                    return null;
                }
            }
        }

        public Merke deleteMerke(int id)
        {
            using (var db = new NettbutikkContext())
            {
                try
                {
                    var slettet = db.Merker.Remove(db.Merker.Find(id));
                    return new Merke() { merkeId = slettet.MerkerId, navn = slettet.Navn };
                }
                catch (Exception feil)
                {
                    return null;
                }
            }
        }

        public List<ForHvem> getFor()
        {
            using (var db = new NettbutikkContext())
            {
                try
                {
                    return db.For.Select(f => new ForHvem(){ forId = f.ForId, navn = f.Navn }).ToList();
                }
                catch (Exception feil)
                {
                    return null;
                }
            }
        }

        public ForHvem getFor(int id)
        {
            using (var db = new NettbutikkContext())
            {
                try
                {
                    var funnet = db.For.Find(id);
                    return new ForHvem() { forId = funnet.ForId, navn = funnet.Navn };
                }
                catch (Exception feil)
                {
                    return null;
                }
            }
        }

        public Kategori getKategori(int id)
        {
            using (var db = new NettbutikkContext())
            {
                try
                {
                    var funnet = db.Kategorier.Find(id);
                    return new Kategori() { kategoriId = funnet.KategoriId, navn = funnet.Navn };
                }
                catch (Exception feil)
                {
                    return null;
                }
            }
        }

        public List<Kategori> getKategorier()
        {
            using (var db = new NettbutikkContext())
            {
                try
                {
                    return db.Kategorier.Select(k => new Kategori() {
                        kategoriId = k.KategoriId, navn = k.Navn
                    }).ToList();
                }
                catch (Exception feil)
                {
                    return null;
                }
            }
        }

        public List<Merke> getMerke()
        {
            using (var db = new NettbutikkContext())
            {
                try
                {
                    return db.Merker.Select(m => new Merke() { merkeId = m.MerkerId, navn = m.Navn }).ToList();
                }
                catch (Exception feil)
                {
                    return null;
                }
            }
        }

        public Merke getMerke(int id)
        {
            using (var db = new NettbutikkContext())
            {
                try
                {
                    var funnet = db.Merker.Find(id);
                    return new Merke() { merkeId = funnet.MerkerId, navn = funnet.Navn };
                }
                catch (Exception feil)
                {
                    return null;
                }
            }
        }

        public ForHvem updateFor(ForHvem forhvem)
        {
            using (var db = new NettbutikkContext())
            {
                try
                {
                    var funnet = db.For.Find(forhvem.forId);
                    funnet.Navn = forhvem.navn;
                    db.SaveChanges();
                    return forhvem;
                }
                catch (Exception feil)
                {
                    return null;
                }
            }
        }

        public Kategori updateKategori(Kategori kategori)
        {
            using (var db = new NettbutikkContext())
            {
                try
                {
                    var funnet = db.Kategorier.Find(kategori.kategoriId);
                    funnet.Navn = kategori.navn;
                    db.SaveChanges();
                    return kategori;
                }
                catch (Exception feil)
                {
                    return null;
                }
            }
        }

        public Merke updateMerke(Merke merke)
        {
            using (var db = new NettbutikkContext())
            {
                try
                {
                    var funnet = db.Merker.Find(merke.merkeId);
                    funnet.Navn = merke.navn;
                    db.SaveChanges();
                    return merke;
                }
                catch (Exception feil)
                {
                    return null;
                }
            }
        }
    }
}
