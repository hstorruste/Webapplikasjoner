using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Nettbutikk;
using DAL.Nettbutikk;

namespace DAL.Admin
{
    public class DbKunder : IDbKunder
    {
        public Kunde getKunde(int id)
        {
            using (var db = new NettbutikkContext())
            {
                try
                {
                    var funnet = db.Kunder.Find(id);
                    return new Kunde()
                    {
                        id = funnet.Id,
                        fornavn = funnet.Fornavn,
                        etternavn = funnet.Etternavn,
                        adresse = funnet.Adresse,
                        postnr = funnet.Postnr,
                        poststed = funnet.Poststeder.Poststed,
                        epost = funnet.Epost
                    };
                }
                catch (Exception feil)
                {
                    return null;
                }
            }
        }

        public List<Kunde> getKunder()
        {
            using (var db = new NettbutikkContext())
            {
                try
                {
                    return db.Kunder.Select(k => new Kunde()
                    {
                        id = k.Id,
                        fornavn = k.Fornavn,
                        etternavn = k.Etternavn,
                        adresse = k.Adresse,
                        postnr = k.Postnr,
                        poststed = k.Poststeder.Poststed,
                        epost = k.Epost
                    }).ToList();
                }
                catch (Exception feil)
                {
                    return null;
                }
            }
        }
    }
}
