using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nettbutikk.Model;
using Nettbutikk.DAL;

namespace BLL
{
    public interface ISkoLogikk
    {
        List<Skoen> hentAlleSko();
        List<Skoen> hentAlleSkoFor(int forHvemId);
        List<Skoen> hentAlleSkoFor(int forHvemId, int kategoriId);
        Skoen hentEnSko(int skoId);
        List<ForHvem> hentAlleForHvem();
        List<Kategori> hentAlleKategorierForHvem(int forHvemId);
        ForHvem getFor(int forId);
        Kategori getKategori(int kategoriId);
    }
}
