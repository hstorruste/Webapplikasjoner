using Model.Nettbutikk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Admin
{
    public interface IKundeLogikk
    {
        List<Kunde> getKunder();
        Kunde getKunde(int id);
    }
}
