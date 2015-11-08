using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Nettbutikk;
using DAL.Admin;

namespace BLL.Admin
{
    public class OrdreBLL : IOrdreLogikk
    {
        private IDbOrdrer _repo;

        public OrdreBLL()
        {
            _repo = new DbOrdrer();
        }

        public OrdreBLL(DbOrdrerStub stub)
        {
            _repo = stub;
        }
        public Ordre getOrdre(int id)
        {
            throw new NotImplementedException();
        }

        public List<Ordre> getOrdrer()
        {
            return _repo.getOrdrer();
        }
    }
}
