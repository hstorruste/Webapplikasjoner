using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nettbutikk.Model;
using Admin.DAL;

namespace Admin.BLL
{
    public class AttributtBLL : IAttributtLogikk
    {
        private IDbAttributter _repo;

        public AttributtBLL()
        {
            _repo = new DbAttributter();
        }

        public AttributtBLL(DbAttributterStub stub)
        {
            _repo = stub;
        }

        public ForHvem addFor(string forNavn)
        {
            return _repo.addFor(forNavn);
        }

        public Kategori addKategori(string kategoriNavn)
        {
            return _repo.addKategori(kategoriNavn);
        }

        public Merke addMerke(string merkeNavn)
        {
            return _repo.addMerke(merkeNavn);
        }

        public ForHvem deleteFor(int id)
        {
            return _repo.deleteFor(id);
        }

        public Kategori deleteKategori(int id)
        {
            return _repo.deleteKategori(id);
        }

        public Merke deleteMerke(int id)
        {
            return _repo.deleteMerke(id);
        }

        public List<ForHvem> getFor()
        {
            return _repo.getFor();
        }

        public ForHvem getFor(int id)
        {
            return _repo.getFor(id);
        }

        public Kategori getKategori(int id)
        {
            return _repo.getKategori(id);
        }

        public List<Kategori> getKategorier()
        {
            return _repo.getKategorier();
        }

        public List<Merke> getMerke()
        {
            return _repo.getMerke();
        }

        public Merke getMerke(int id)
        {
            return _repo.getMerke(id);
        }

        public List<Skoen> getSkoAvFor(int id)
        {
            return _repo.getSkoAvFor(id);
        }

        public List<Skoen> getSkoAvKategori(int id)
        {
            return _repo.getSkoAvKategori(id);
        }

        public List<Skoen> getSkoAvMerke(int id)
        {
            return _repo.getSkoAvMerke(id);
        }

        public ForHvem updateFor(ForHvem forhvem)
        {
            return _repo.updateFor(forhvem);
        }

        public Kategori updateKategori(Kategori kategori)
        {
            return _repo.updateKategori(kategori);
        }

        public Merke updateMerke(Merke merke)
        {
            return _repo.updateMerke(merke);
        }
    }
}
