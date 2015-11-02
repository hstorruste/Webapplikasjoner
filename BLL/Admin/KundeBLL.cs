using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nettbutikk.Model;
using DAL.Admin;

namespace BLL.Admin
{
    public class KundeBLL : IKundeLogikk
    {
        private IDbKunder _repo;

        public KundeBLL()
        {
            _repo = new DbKunder();
        }

        public KundeBLL(DbKunderStub stub)
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
