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
        Kategori updateKategori();
        ForHvem updateFor();
        Merke updateMerke();
        Merke deleteKategori();
        ForHvem deleteFor();
        Kategori deleteMerke();
    }
}
