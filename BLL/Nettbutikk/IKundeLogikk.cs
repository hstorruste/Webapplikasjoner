using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nettbutikk.DAL;
using Nettbutikk.Model;

namespace Nettbutikk.BLL
{
    public interface IKundeLogikk
    {
        KundeModell getKunde(string epost);
        int getKundePassord(int innPassordId);
        bool registrerKunde(RegistrerKundeModell innKunde);
        RedigerKundeModell hentEnKunde(int id);
        bool redigerKunde(RedigerKundeModell innKunde);
        RedigerKundePassordModell hentEnKundePassord(int passordId);
        bool redigerKundePassord(RedigerKundePassordModell innPassord);
        byte[] lagHash(string innPassord);
        bool Kunde_i_DB(LoggInnModell innKunde);
        Ordre getOrdre(int ordreId);
        bool arkiverOrdre(string sessionId, int kundeId);
        List<Ordre> finnAlleOrdre(int KundeId);
        Ordre finnSisteOrdre(int KundeId);
    }
}
