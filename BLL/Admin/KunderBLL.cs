using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nettbutikk.Model;
using DAL.Admin;

namespace BLL.Admin
{
    public class KunderBLL : IKunderBLL
    {
        private IDbKunder _repo;

        public KunderBLL()
        {
            _repo = new DbKunder();
        }

        public KunderBLL(DbKunderStub stub)
        {
            _repo = stub;
        }
        public Kunde getKunde(int id)
        {
            return _repo.getKunde(id);
        }

        public List<Kunde> getKunder()
        {
            return _repo.getKunder();
        }
    }
}
