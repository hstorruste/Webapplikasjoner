using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Nettbutikk;
using DAL.Nettbutikk;

namespace DAL.Admin
{
    public class DbKunderStub : IDbKunder
    {
        public Kunde getKunde(int id)
        {
            var enKunde = new Kunde
            {
                id = 1,
                fornavn = "Adrian",
                etternavn = "Westlund",
                adresse = "Årvollveien 60D",
                postnr = "0590",
                poststed = "Oslo",
                epost = "adrianwestlund@gmail.com",
                passordId = 1
            };

            if (id == enKunde.id)
            {
                return enKunde;
            }
            else
            {
                return null;
            }
        }

        public List<Kunde> getKunder()
        {
            var liste = new List<Kunde>
            {
                new Kunde
                {
                    id = 1,
                    fornavn = "Adrian",
                    etternavn = "Westlund",
                    adresse = "Årvollveien 60D",
                    postnr = "0590",
                    poststed = "Oslo",
                    epost = "adrianwestlund@gmail.com",
                    passordId = 1
                },
                new Kunde
                {
                    id = 2,
                    fornavn = "Per",
                    etternavn = "Andersson",
                    adresse = "Svenskagatan 1",
                    postnr = "0655",
                    poststed = "Oslo",
                    epost = "per@gmail.com",
                    passordId = 2
                },
                new Kunde
                {
                    id = 3,
                    fornavn = "Kalle",
                    etternavn = "Anka",
                    adresse = "Ankgatan 4C",
                    postnr = "6542",
                    poststed = "Ankeborg",
                    epost = "ka@anka.com",
                    passordId = 3
                }
            };

            return liste;
        }
    }
}
