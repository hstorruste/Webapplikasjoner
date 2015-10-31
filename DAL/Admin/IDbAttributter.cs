using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nettbutikk.Model;
using Nettbutikk.DAL;

namespace Admin.DAL
{
    public interface IDbAttributter
    {
        List<Kategori> getKategorier();
        List<ForHvem> getFor();
        List<Merke> getMerke();
        Kategori getKategori(int id);
        ForHvem getFor(int id);
        Merke getMerke(int id);
        Kategori updateKategori(Kategori kategori);
        ForHvem updateFor(ForHvem forhvem);
        Merke updateMerke(Merke merke);
        Kategori deleteKategori(int id);
        ForHvem deleteFor(int id);
        Merke deleteMerke(int id);
        Merke addMerke(string merkeNavn);
        ForHvem addFor(string forNavn);
        Kategori addKategori(string kategoriNavn);
    }
}
