using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nettbutikk.DAL;
using Nettbutikk.Model;

namespace Nettbutikk.BLL
{
    public class HandlevognBLL : IHandlevognLogikk
    {
        public int antallHandlevognVarer(string sessionId)
        {
            return DbHandlevogn.antallHandlevognVarer(sessionId);
        }

        public bool fjernAlleVarer(string sessionId)
        {
            return DbHandlevogn.fjernAlleVarer(sessionId);
        }

        public bool fjernVare(int vareId)
        {
            return DbHandlevogn.fjernVare(vareId);
        }

        public List<HandlevognVare> getAlleKundevognvarer(string sessionId)
        {
            return DbHandlevogn.getAlleKundevognvarer(sessionId);
        }

        public Handlevogn getHandlevogn(string sessionId)
        {
            return DbHandlevogn.getHandlevogn(sessionId);
        }

        public decimal getTotalpris(string sessionId)
        {
            return DbHandlevogn.getTotalpris(sessionId);
        }

        public Ordrer lagOrdre(string sessionId, int kundeId)
        {
            return DbHandlevogn.lagOrdre(sessionId, kundeId);
        }

        public Ordre lagTempOrdre(string sessionId, int kundeId)
        {
            return DbHandlevogn.lagTempOrdre(sessionId, kundeId);
        }

        public bool leggTilVare(string sessionId, int skoId, int skoStr)
        {
            return DbHandlevogn.leggTilVare(sessionId,skoId,skoStr);
        }

        public bool slettAlleHandlevognVarer(string sessionId)
        {
            return DbHandlevogn.slettAlleHandlevognVarer(sessionId);
        }
    }
}
