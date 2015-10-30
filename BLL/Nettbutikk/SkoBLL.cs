using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nettbutikk.DAL;
using Nettbutikk.Model;

namespace Nettbutikk.BLL
{
    public class SkoBLL : ISkoLogikk
    {
        public List<Skoen> hentAlleSko()
        {
            return DbSko.hentAlleSko();
        }

        public List<Skoen> hentAlleSkoFor(int forHvemId)
        {
            return DbSko.hentAlleSkoFor(forHvemId);
        }

        public List<Skoen> hentAlleSkoFor(int forHvemId, int kategoriId)
        {
            return DbSko.hentAlleSkoFor(forHvemId, kategoriId);
        }

        public Skoen hentEnSko(int skoId)
        {
            return DbSko.hentEnSko(skoId);
        }

        public List<ForHvem> hentAlleForHvem()
        {
            return DbSko.hentAlleForHvem();
        }

        public List<Kategori> hentAlleKategorierForHvem(int forHvemId)
        {
            return DbSko.hentAlleKategorierForHvem(forHvemId);
        }

        public ForHvem getFor(int forId)
        {
            return DbSko.getFor(forId);
        }

        public Kategori getKategori(int kategoriId)
        {
            return DbSko.getKategori(kategoriId);
        }
    }
}
