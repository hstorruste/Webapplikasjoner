using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Nettbutikk;
using DAL.Nettbutikk;

namespace DAL.Admin
{
    public class DbOrdrer : IDbOrdrer
    {
        public Ordre getOrdre(int id)
        {
            using (var db = new NettbutikkContext())
            {
                try
                {
                    var funnet = db.Ordrer.Find(id);
                    DbKunder dbKunder = new DbKunder();
                    Kunde kunde = dbKunder.getKunde(funnet.KundeId);
                    //HandlevognVare varer = DbHandlevogn.
                    return new Ordre()
                    {
                        ordreId = funnet.OrdreId,
                        kundeId = funnet.KundeId,
                        ordreDato = funnet.OrdreDato,
                        //varer = funnet.,
                        totalBelop = funnet.TotalBelop,
                        kundeNavn = kunde.fornavn + " " + kunde.etternavn,
                        adresse = kunde.adresse,
                        postnr = kunde.postnr,
                        poststed = kunde.poststed,
                    };
                }
                catch (Exception feil)
                {
                    ErrorHandler.logError(feil);
                    return null;
                }
            }
        }

        public List<Ordre> getOrdrer()
        {
            using (var db = new NettbutikkContext())
            {
                try
                {
                    return db.Ordrer.Select(o => new Ordre()
                    {
                        /*ordreId = o.OrdreId,
                        fornavn = k.Fornavn,
                        etternavn = k.Etternavn,
                        adresse = k.Adresse,
                        postnr = k.Postnr,
                        poststed = k.Poststeder.Poststed,
                        epost = k.Epost*/
                    }).ToList();
                }
                catch (Exception feil)
                {
                    ErrorHandler.logError(feil);
                    return null;
                }
            }
        }
    }
}

