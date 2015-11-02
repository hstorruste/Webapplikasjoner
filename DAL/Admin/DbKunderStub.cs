using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nettbutikk.Model;

namespace DAL.Admin
{
    public class DbKunderStub : IDbKunder
    {
        public Kunde getKunde(int id)
        {
            throw new NotImplementedException();
        }

        public List<Kunde> getKunder()
        {
            throw new NotImplementedException();
        }
    }
}
