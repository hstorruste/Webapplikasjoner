using Model.Nettbutikk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Admin
{
    public interface ISkoLogikk
    {
        List<Skoen> getAktuelleSko();
        List<Skoen> getSlettedeSko();
    }
}
