using Model.Nettbutikk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Admin
{
    public interface IDbSko
    {
        List<Skoen> getAktuelleSko();
        List<Skoen> getSlettedeSko();

    }
}
