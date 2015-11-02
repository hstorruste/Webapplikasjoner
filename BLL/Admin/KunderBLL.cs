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
        public Kunde getKunde(int id)
        {
            var DbKunder = new DbKunder();
            return DbKunder.getKunde(id);
        }

        public List<Kunde> getKunder()
        {
            var DbKunder = new DbKunder();
            List<Kunde> alleKunder = DbKunder.getKunder();
            return alleKunder;
        }
    }
}
