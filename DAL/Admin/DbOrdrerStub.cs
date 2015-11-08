using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Nettbutikk;

namespace DAL.Admin
{
    public class DbOrdrerStub : IDbOrdrer
    {
        public Ordre getOrdre(int id)
        {
            throw new NotImplementedException();
        }

        public List<Ordre> getOrdrer()
        {
            throw new NotImplementedException();
        }
    }
}
