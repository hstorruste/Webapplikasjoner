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
                    Ordrer enOrdre = db.Ordrer.Include("OrdreDetaljer.Sko.Merke").Include("OrdreDetaljer.Sko.Bilder").Include("Kunder.Poststeder")
                        .SingleOrDefault(o => o.OrdreId == id);
                    return new Ordre()
                    {
                        ordreId = enOrdre.OrdreId,
                        ordreDato = enOrdre.OrdreDato,
                        kundeId = enOrdre.KundeId,
                        kundeNavn = enOrdre.Kunder.Fornavn + " " + enOrdre.Kunder.Etternavn,
                        adresse = enOrdre.Kunder.Adresse,
                        postnr = enOrdre.Kunder.Postnr,
                        poststed = enOrdre.Kunder.Poststeder.Poststed,
                        varer = enOrdre.OrdreDetaljer.Select(d => new HandlevognVare
                        {
                            skoId = d.Sko.SkoId,
                            skoNavn = d.Sko.Navn,
                            merke = d.Sko.Merke.Navn,
                            farge = d.Sko.Farge,
                            storlek = d.Storlek,
                            pris = d.Pris,
                            bildeUrl = d.Sko.Bilder.Where(b => b.BildeUrl.Contains("/Medium/")).FirstOrDefault().BildeUrl,
                        }).ToList(),
                        totalBelop = enOrdre.TotalBelop
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
                    List<Ordre> alleOrdre = db.Ordrer.Select(o => new Ordre()
                    {
                        ordreId = o.OrdreId,
                        ordreDato = o.OrdreDato,
                        kundeId = o.KundeId,
                        kundeNavn = o.Kunder.Fornavn + " " + o.Kunder.Etternavn,
                        adresse = o.Kunder.Adresse,
                        postnr = o.Kunder.Postnr,
                        poststed = o.Kunder.Poststeder.Poststed,
                        varer = o.OrdreDetaljer.Select(d => new HandlevognVare
                        {
                            skoId = d.Sko.SkoId,
                            skoNavn = d.Sko.Navn,
                            merke = d.Sko.Merke.Navn,
                            farge = d.Sko.Farge,
                            storlek = d.Storlek,
                            pris = d.Pris,
                            bildeUrl = d.Sko.Bilder.Where(b => b.BildeUrl.Contains("/Medium/")).FirstOrDefault().BildeUrl,
                        }).ToList(),
                        totalBelop = o.TotalBelop
                    }).ToList();
                    return alleOrdre;
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

