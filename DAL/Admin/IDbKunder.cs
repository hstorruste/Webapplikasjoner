using System;
using System.Collections.Generic;
using System.Linq;
using Model.Nettbutikk;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Admin
{
    public interface IDbKunder
    {
        List<Kunde> getKunder();
        Kunde getKunde(int id);
    }
}
