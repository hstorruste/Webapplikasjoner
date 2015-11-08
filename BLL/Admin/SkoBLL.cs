using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Nettbutikk;
using DAL.Admin;

namespace BLL.Admin
{
    public class SkoBLL : ISkoLogikk
    {
        IDbSko _repo;
        public SkoBLL()
        {
            _repo = new DbSko();
        }

        public SkoBLL( IDbSko stub)
        {
            _repo = stub;
        }

        public List<Skoen> getAktuelleSko()
        {
            return _repo.getAktuelleSko();
        }

        public List<Pris> getPrishistorikk(int skoId)
        {
            return _repo.getPrishistorikk(skoId);
        }

        public Skoen getSko(int id)
        {
            return _repo.getSko(id);
        }

        public List<Skoen> getSlettedeSko()
        {
            return _repo.getSlettedeSko();
        }

        public Skoen gjenopprett(int id)
        {
            return _repo.gjenopprett(id);
        }

        public Skoen lagreSko(Skoen innsko)
        {
            return _repo.lagreSko(innsko);
        }

        public Bilde leggTilBilde(int skoId, Bilde innBilde)
        {
            return _repo.leggTilBilde(skoId, innBilde);
        }

        public Storlek leggTilStorlek(int skoId, Storlek innStr)
        {
            return _repo.leggTilStorlek(skoId, innStr);
        }

        public Skoen slett(int id)
        {
            return _repo.slett(id);
        }

        public Bilde slettBilde(int id)
        {
            return _repo.slettBilde(id);
        }

        public Storlek slettStorlek(int id)
        {
            return _repo.slettStorlek(id);
        }
    }
}
