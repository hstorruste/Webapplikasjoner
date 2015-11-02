using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nettbutikk.Model;

namespace Admin.DAL
{
    public class DbAttributterStub : IDbAttributter
    {
        public ForHvem addFor(string forNavn)
        {
            throw new NotImplementedException();
        }

        public Kategori addKategori(string kategoriNavn)
        {
            throw new NotImplementedException();
        }

        public Merke addMerke(string merkeNavn)
        {
            throw new NotImplementedException();
        }

        public ForHvem deleteFor(int id)
        {
            throw new NotImplementedException();
        }

        public Kategori deleteKategori(int id)
        {
            throw new NotImplementedException();
        }

        public Merke deleteMerke(int id)
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

        public List<Skoen> getSkoAvFor(int id)
        {
            throw new NotImplementedException();
        }

        public List<Skoen> getSkoAvKategori(int id)
        {
            throw new NotImplementedException();
        }

        public List<Skoen> getSkoAvMerke(int id)
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
