using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nettbutikk.DAL;
using Nettbutikk.Model;

namespace BLL
{
    public class KunderBLL : IKundeLogikk
    {
        public bool arkiverOrdre(string sessionId, int kundeId)
        {
            return DbKunder.arkiverOrdre(sessionId, kundeId);
        }

        public List<Ordre> finnAlleOrdre(int KundeId)
        {
            return DbKunder.finnAlleOrdre(KundeId);
        }

        public Ordre finnSisteOrdre(int KundeId)
        {
            return DbKunder.finnSisteOrdre(KundeId);
        }

        public KundeModell getKunde(string epost)
        {
            return DbKunder.getKunde(epost);
        }

        public int getKundePassord(int innPassordId)
        {
            return DbKunder.getKundePassord(innPassordId);
        }

        public Ordre getOrdre(int ordreId)
        {
            return DbKunder.getOrdre(ordreId);
        }

        public RedigerKundeModell hentEnKunde(int id)
        {
            return DbKunder.hentEnKunde(id);
        }

        public RedigerKundePassordModell hentEnKundePassord(int passordId)
        {
            return DbKunder.hentEnKundePassord(passordId);
        }

        public bool Kunde_i_DB(LoggInnModell innKunde)
        {
            return DbKunder.Kunde_i_DB(innKunde);
        }

        public byte[] lagHash(string innPassord)
        {
            return DbKunder.lagHash(innPassord);
        }

        public bool redigerKunde(RedigerKundeModell innKunde)
        {
            return DbKunder.redigerKunde(innKunde);
        }

        public bool redigerKundePassord(RedigerKundePassordModell innPassord)
        {
            return DbKunder.redigerKundePassord(innPassord);
        }

        public bool registrerKunde(RegistrerKundeModell innKunde)
        {
            return DbKunder.registrerKunde(innKunde);
        }
    }
}
