using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Nettbutikk;
using DAL.Nettbutikk;

namespace DAL.Admin
{
    public class DbSkoStub : IDbSko
    {
        public List<Skoen> getAktuelleSko()
        {
            var skoene = new List<Skoen>
            {
                new Skoen { skoId = 1, navn = "B&CO 2455100311", beskrivelse= "Tøff B&CO damesko med lisser. Skoen er i tekstil med små metall nitter. Den har sort kantbånd rundt lisser stykket og langs kanten. Skoen er sort med brune flammer. Den har canvas dekksåle og canvas fôr. Gummisålen er tofarget hvit og sort.",
                        merke = "B&CO", farge = "Sort", forHvem = "Dame", kategori = "Sko", pris = 499.00M,
                        storlekar = new List<Storlek>
                        {
                            new Storlek { storlekId = 1, storlek = 36, antall = 10 },
                            new Storlek { storlekId = 2, storlek = 37, antall = 11 },
                            new Storlek { storlekId = 3, storlek = 38, antall = 12 },
                            new Storlek { storlekId = 4, storlek = 39, antall = 13 },
                            new Storlek { storlekId = 5, storlek = 40, antall = 14 },
                            new Storlek { storlekId = 6, storlek = 41, antall = 15 }
                        }, bilder = new List<Bilde>
                        {
                            new Bilde { bildeId = 1, bildeUrl = "bilde1.jpg" },
                            new Bilde { bildeId = 2, bildeUrl = "bilde2.jpg" },
                            new Bilde { bildeId = 3, bildeUrl = "bilde3.jpg" },
                        }

                },
                new Skoen { skoId = 2, navn = "Sanita 538665", beskrivelse = "" ,
                        merke = "Sanita", farge = "Grønn", forHvem = "Herre", kategori = "Gummistøvler", pris = 249.00M,
                        storlekar = new List<Storlek>
                        {
                            new Storlek { storlekId = 7, storlek = 36, antall = 10 },
                            new Storlek { storlekId = 8, storlek = 37, antall = 11 },
                            new Storlek { storlekId = 9, storlek = 38, antall = 12 },
                            new Storlek { storlekId = 10, storlek = 39, antall = 13 },
                            new Storlek { storlekId = 11, storlek = 40, antall = 14 },
                            new Storlek { storlekId = 12, storlek = 41, antall = 15 },
                            new Storlek { storlekId = 13, storlek = 42, antall = 16 },
                            new Storlek { storlekId = 14, storlek = 43, antall = 17 },
                            new Storlek { storlekId = 15, storlek = 44, antall = 18 },
                            new Storlek { storlekId = 16, storlek = 45, antall = 19 },
                            new Storlek { storlekId = 17, storlek = 46, antall = 20 }
                        }, bilder = new List<Bilde>
                        {
                            new Bilde { bildeId = 1, bildeUrl = "bilde1.jpg" },
                            new Bilde { bildeId = 2, bildeUrl = "bilde2.jpg" },
                            new Bilde { bildeId = 3, bildeUrl = "bilde3.jpg" },
                        }
                },
                new Skoen { skoId = 3, navn = "92-98024", beskrivelse= "",
                        merke = "Duffy", farge = "Sort", forHvem = "Dame", kategori = "Gummistøvler", pris = 399.00M,
                        storlekar = new List<Storlek>
                        {
                            new Storlek { storlekId = 1, storlek = 36, antall = 10 },
                            new Storlek { storlekId = 2, storlek = 37, antall = 11 },
                            new Storlek { storlekId = 3, storlek = 38, antall = 12 },
                            new Storlek { storlekId = 4, storlek = 39, antall = 13 },
                            new Storlek { storlekId = 5, storlek = 40, antall = 14 },
                            new Storlek { storlekId = 6, storlek = 41, antall = 15 }
                        }, bilder = new List<Bilde>
                        {
                            new Bilde { bildeId = 1, bildeUrl = "bilde1.jpg" },
                            new Bilde { bildeId = 2, bildeUrl = "bilde2.jpg" },
                            new Bilde { bildeId = 3, bildeUrl = "bilde3.jpg" },
                        }
                },
            }.ToList();
            
            return skoene;
        }

        public List<Pris> getPrishistorikk(int skoId)
        {
            var liste = new List<Pris>
            {
                new Pris { skoId = 1, skoNavn = "B&CO 2455100311",
                            dato = new DateTime(2014,01,25,9,0,0), pris = 399.00M },
                new Pris { skoId = 1, skoNavn = "B&CO 2455100311",
                            dato = new DateTime(2014,04,15,9,30,50), pris = 359.00M },
                new Pris { skoId = 1, skoNavn = "B&CO 2455100311",
                            dato = new DateTime(2014,09,10,12,0,0), pris = 399.00M },
                new Pris { skoId = 1, skoNavn = "B&CO 2455100311",
                            dato = new DateTime(2014,12,1,9,0,0), pris = 299.00M },
                new Pris { skoId = 1, skoNavn = "B&CO 2455100311",
                            dato = new DateTime(2015,01,1,15,30,0), pris = 349.00M }
            };

            if(skoId == liste[0].skoId)
            {
                return liste;
            }
            else
            {
                return null;
            }
        }

        public Skoen getSko(int id)
        {
            var enSko = new Skoen
            {
                skoId = 1,
                navn = "B&CO 2455100311",
                beskrivelse = "Tøff B&CO damesko med lisser. Skoen er i tekstil med små metall nitter. Den har sort kantbånd rundt lisser stykket og langs kanten. Skoen er sort med brune flammer. Den har canvas dekksåle og canvas fôr. Gummisålen er tofarget hvit og sort.",
                merke = "B&CO",
                farge = "Sort",
                forHvem = "Dame",
                kategori = "Sko",
                pris = 499.00M,
                storlekar = new List<Storlek>
                        {
                            new Storlek { storlekId = 1, storlek = 36, antall = 10 },
                            new Storlek { storlekId = 2, storlek = 37, antall = 11 },
                            new Storlek { storlekId = 3, storlek = 38, antall = 12 },
                            new Storlek { storlekId = 4, storlek = 39, antall = 13 },
                            new Storlek { storlekId = 5, storlek = 40, antall = 14 },
                            new Storlek { storlekId = 6, storlek = 41, antall = 15 }
                        },
                bilder = new List<Bilde>
                        {
                            new Bilde { bildeId = 1, bildeUrl = "bilde1.jpg" },
                            new Bilde { bildeId = 2, bildeUrl = "bilde2.jpg" },
                            new Bilde { bildeId = 3, bildeUrl = "bilde3.jpg" },
                        }
            };

            if(id == enSko.skoId)
            {
                return enSko;
            }
            else
            {
                return null;
            }
        }

        public List<Skoen> getSlettedeSko()
        {
            var skoene = new List<Skoen>
            {
                new Skoen { skoId = 1, navn = "B&CO 2455100311", beskrivelse= "Tøff B&CO damesko med lisser. Skoen er i tekstil med små metall nitter. Den har sort kantbånd rundt lisser stykket og langs kanten. Skoen er sort med brune flammer. Den har canvas dekksåle og canvas fôr. Gummisålen er tofarget hvit og sort.",
                        merke = "B&CO", farge = "Sort", forHvem = "Dame", kategori = "Sko", pris = 499.00M,
                        storlekar = new List<Storlek>
                        {
                            new Storlek { storlekId = 1, storlek = 36, antall = 10 },
                            new Storlek { storlekId = 2, storlek = 37, antall = 11 },
                            new Storlek { storlekId = 3, storlek = 38, antall = 12 },
                            new Storlek { storlekId = 4, storlek = 39, antall = 13 },
                            new Storlek { storlekId = 5, storlek = 40, antall = 14 },
                            new Storlek { storlekId = 6, storlek = 41, antall = 15 }
                        }, bilder = new List<Bilde>
                        {
                            new Bilde { bildeId = 1, bildeUrl = "bilde1.jpg" },
                            new Bilde { bildeId = 2, bildeUrl = "bilde2.jpg" },
                            new Bilde { bildeId = 3, bildeUrl = "bilde3.jpg" },
                        }

                },
                new Skoen { skoId = 2, navn = "Sanita 538665", beskrivelse = "" ,
                        merke = "Sanita", farge = "Grønn", forHvem = "Herre", kategori = "Gummistøvler", pris = 249.00M,
                        storlekar = new List<Storlek>
                        {
                            new Storlek { storlekId = 7, storlek = 36, antall = 10 },
                            new Storlek { storlekId = 8, storlek = 37, antall = 11 },
                            new Storlek { storlekId = 9, storlek = 38, antall = 12 },
                            new Storlek { storlekId = 10, storlek = 39, antall = 13 },
                            new Storlek { storlekId = 11, storlek = 40, antall = 14 },
                            new Storlek { storlekId = 12, storlek = 41, antall = 15 },
                            new Storlek { storlekId = 13, storlek = 42, antall = 16 },
                            new Storlek { storlekId = 14, storlek = 43, antall = 17 },
                            new Storlek { storlekId = 15, storlek = 44, antall = 18 },
                            new Storlek { storlekId = 16, storlek = 45, antall = 19 },
                            new Storlek { storlekId = 17, storlek = 46, antall = 20 }
                        }, bilder = new List<Bilde>
                        {
                            new Bilde { bildeId = 1, bildeUrl = "bilde1.jpg" },
                            new Bilde { bildeId = 2, bildeUrl = "bilde2.jpg" },
                            new Bilde { bildeId = 3, bildeUrl = "bilde3.jpg" },
                        }
                },
                new Skoen { skoId = 3, navn = "92-98024", beskrivelse= "",
                        merke = "Duffy", farge = "Sort", forHvem = "Dame", kategori = "Gummistøvler", pris = 399.00M,
                        storlekar = new List<Storlek>
                        {
                            new Storlek { storlekId = 1, storlek = 36, antall = 10 },
                            new Storlek { storlekId = 2, storlek = 37, antall = 11 },
                            new Storlek { storlekId = 3, storlek = 38, antall = 12 },
                            new Storlek { storlekId = 4, storlek = 39, antall = 13 },
                            new Storlek { storlekId = 5, storlek = 40, antall = 14 },
                            new Storlek { storlekId = 6, storlek = 41, antall = 15 }
                        }, bilder = new List<Bilde>
                        {
                            new Bilde { bildeId = 1, bildeUrl = "bilde1.jpg" },
                            new Bilde { bildeId = 2, bildeUrl = "bilde2.jpg" },
                            new Bilde { bildeId = 3, bildeUrl = "bilde3.jpg" },
                        }
                },
            }.ToList();

            return skoene;
        }

        public Skoen gjenopprett(int id)
        {
            var enSko = new Skoen
            {
                skoId = 1,
                navn = "B&CO 2455100311",
                beskrivelse = "Tøff B&CO damesko med lisser. Skoen er i tekstil med små metall nitter. Den har sort kantbånd rundt lisser stykket og langs kanten. Skoen er sort med brune flammer. Den har canvas dekksåle og canvas fôr. Gummisålen er tofarget hvit og sort.",
                merke = "B&CO",
                farge = "Sort",
                forHvem = "Dame",
                kategori = "Sko",
                pris = 499.00M,
                storlekar = new List<Storlek>
                        {
                            new Storlek { storlekId = 1, storlek = 36, antall = 10 },
                            new Storlek { storlekId = 2, storlek = 37, antall = 11 },
                            new Storlek { storlekId = 3, storlek = 38, antall = 12 },
                            new Storlek { storlekId = 4, storlek = 39, antall = 13 },
                            new Storlek { storlekId = 5, storlek = 40, antall = 14 },
                            new Storlek { storlekId = 6, storlek = 41, antall = 15 }
                        },
                bilder = new List<Bilde>
                        {
                            new Bilde { bildeId = 1, bildeUrl = "bilde1.jpg" },
                            new Bilde { bildeId = 2, bildeUrl = "bilde2.jpg" },
                            new Bilde { bildeId = 3, bildeUrl = "bilde3.jpg" },
                        }
            };

            if (id == enSko.skoId)
            {
                return enSko;
            }
            else
            {
                return null;
            }
        }

        public Skoen lagreSko(Skoen innsko)
        {
            throw new NotImplementedException();
        }

        public Bilde leggTilBilde(int skoId, Bilde innBilde)
        {
            throw new NotImplementedException();
        }

        public Storlek leggTilStorlek(int skoId, Storlek innStr)
        {
            throw new NotImplementedException();
        }

        public Skoen slett(int id)
        {
            var enSko = new Skoen
            {
                skoId = 1,
                navn = "B&CO 2455100311",
                beskrivelse = "Tøff B&CO damesko med lisser. Skoen er i tekstil med små metall nitter. Den har sort kantbånd rundt lisser stykket og langs kanten. Skoen er sort med brune flammer. Den har canvas dekksåle og canvas fôr. Gummisålen er tofarget hvit og sort.",
                merke = "B&CO",
                farge = "Sort",
                forHvem = "Dame",
                kategori = "Sko",
                pris = 499.00M,
                storlekar = new List<Storlek>
                        {
                            new Storlek { storlekId = 1, storlek = 36, antall = 10 },
                            new Storlek { storlekId = 2, storlek = 37, antall = 11 },
                            new Storlek { storlekId = 3, storlek = 38, antall = 12 },
                            new Storlek { storlekId = 4, storlek = 39, antall = 13 },
                            new Storlek { storlekId = 5, storlek = 40, antall = 14 },
                            new Storlek { storlekId = 6, storlek = 41, antall = 15 }
                        },
                bilder = new List<Bilde>
                        {
                            new Bilde { bildeId = 1, bildeUrl = "bilde1.jpg" },
                            new Bilde { bildeId = 2, bildeUrl = "bilde2.jpg" },
                            new Bilde { bildeId = 3, bildeUrl = "bilde3.jpg" },
                        }
            };

            if (id == enSko.skoId)
            {
                return enSko;
            }
            else
            {
                return null;
            }
        }

        public Bilde slettBilde(int id)
        {
            throw new NotImplementedException();
        }

        public Storlek slettStorlek(int id)
        {
            throw new NotImplementedException();
        }
    }
}
