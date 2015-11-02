using Nettbutikk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Admin
{
    public interface IKunderBLL
    {
        List<Kunde> getKunder();
        Kunde getKunde(int id);
    }
}
