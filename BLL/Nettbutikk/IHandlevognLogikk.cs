using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Nettbutikk;
using DAL.Nettbutikk;

namespace BLL.Nettbutikk
{
    public interface IHandlevognLogikk
    {
        Handlevogn getHandlevogn(string sessionId);
        List<HandlevognVare> getAlleKundevognvarer(string sessionId);
        bool leggTilVare(string sessionId, int skoId, int skoStr);
        bool fjernVare(int vareId);
        bool fjernAlleVarer(string sessionId);
        decimal getTotalpris(string sessionId);
        Ordrer lagOrdre(string sessionId, int kundeId);
        Ordre lagTempOrdre(string sessionId, int kundeId);
        bool slettAlleHandlevognVarer(string sessionId);
        int antallHandlevognVarer(string sessionId);
    }
}
