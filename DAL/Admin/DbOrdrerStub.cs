using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Nettbutikk;

namespace DAL.Admin
{
    public class DbOrdrerStub : IDbOrdrer
    {
        public Ordre getOrdre(int id)
        {
            throw new NotImplementedException();
        }

        public List<Ordre> getOrdrer()
        {
            var liste = new List<Ordre>
            {
                new Ordre
                {
                    ordreId = 1,
                    ordreDato = new DateTime(2014,01,25,9,0,0),
                    kundeId = 1,
                    kundeNavn = "Adrian Westlund",
                    adresse = "Årvollveien 60D",
                    postnr = "0590",
                    poststed = "Oslo",
                    varer = new List<HandlevognVare>
                        {
                            new HandlevognVare()
                            {
                            skoId = 1,
                            skoNavn = "Sanita 538665",
                            merke = "Sanita",
                            farge = "Grønn",
                            storlek = 44,
                            pris = 249.00M,
                            bildeUrl = "bilde1.jpg"
                            },
                            new HandlevognVare()
                            {
                            skoId = 1,
                            skoNavn = "Sanita 538665",
                            merke = "Sanita",
                            farge = "Grønn",
                            storlek = 44,
                            pris = 249.00M,
                            bildeUrl = "bilde1.jpg"
                            },
                            new HandlevognVare()
                            {
                            skoId = 1,
                            skoNavn = "Sanita 538665",
                            merke = "Sanita",
                            farge = "Grønn",
                            storlek = 44,
                            pris = 249.00M,
                            bildeUrl = "bilde1.jpg"
                            },
                        },
                        totalBelop = 999.00M
                },
                new Ordre
                {
                    ordreId = 1,
                    ordreDato = new DateTime(2014,01,25,9,0,0),
                    kundeId = 1,
                    kundeNavn = "Adrian Westlund",
                    adresse = "Årvollveien 60D",
                    postnr = "0590",
                    poststed = "Oslo",
                    varer = new List<HandlevognVare>
                        {
                            new HandlevognVare()
                            {
                            skoId = 1,
                            skoNavn = "Sanita 538665",
                            merke = "Sanita",
                            farge = "Grønn",
                            storlek = 44,
                            pris = 249.00M,
                            bildeUrl = "bilde1.jpg"
                            },
                            new HandlevognVare()
                            {
                            skoId = 1,
                            skoNavn = "Sanita 538665",
                            merke = "Sanita",
                            farge = "Grønn",
                            storlek = 44,
                            pris = 249.00M,
                            bildeUrl = "bilde1.jpg"
                            },
                            new HandlevognVare()
                            {
                            skoId = 1,
                            skoNavn = "Sanita 538665",
                            merke = "Sanita",
                            farge = "Grønn",
                            storlek = 44,
                            pris = 249.00M,
                            bildeUrl = "bilde1.jpg"
                            },
                        },
                        totalBelop = 999.00M
                },
                new Ordre
                {
                    ordreId = 1,
                    ordreDato = new DateTime(2014,01,25,9,0,0),
                    kundeId = 1,
                    kundeNavn = "Adrian Westlund",
                    adresse = "Årvollveien 60D",
                    postnr = "0590",
                    poststed = "Oslo",
                    varer = new List<HandlevognVare>
                        {
                            new HandlevognVare()
                            {
                            skoId = 1,
                            skoNavn = "Sanita 538665",
                            merke = "Sanita",
                            farge = "Grønn",
                            storlek = 44,
                            pris = 249.00M,
                            bildeUrl = "bilde1.jpg"
                            },
                            new HandlevognVare()
                            {
                            skoId = 1,
                            skoNavn = "Sanita 538665",
                            merke = "Sanita",
                            farge = "Grønn",
                            storlek = 44,
                            pris = 249.00M,
                            bildeUrl = "bilde1.jpg"
                            },
                            new HandlevognVare()
                            {
                            skoId = 1,
                            skoNavn = "Sanita 538665",
                            merke = "Sanita",
                            farge = "Grønn",
                            storlek = 44,
                            pris = 249.00M,
                            bildeUrl = "bilde1.jpg"
                            },
                        },
                        totalBelop = 999.00M
                }
            };
            return liste;
        }
    }
}
