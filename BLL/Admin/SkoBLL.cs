using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nettbutikk.Model;
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

        public List<Skoen> getSlettedeSko()
        {
            return _repo.getSlettedeSko();
        }
    }
}
