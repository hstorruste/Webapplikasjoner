using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL.Admin;
using DAL.Admin;
using Model.Nettbutikk;
using System.Web.Mvc;
using System.Collections.Generic;
using Microsoft.CSharp;
using Nettbutikk.Areas.Admin.Controllers;
using Nettbutikk.Areas.Admin.Models;

namespace EnhetsTest
{
    [TestClass]
    public class SkoAdminControllerTest
    {
        [TestMethod]
        public void Index_vis_view()
        {
            //Arrange
            var controller = new SkoAdminController(new SkoBLL(new DbSkoStub()));

            //Act
            var resultat = (ViewResult)controller.Index();

            //Assert
            Assert.AreEqual(resultat.ViewName, "");
        }

        [TestMethod]
        public void SkoListe_vis_view()
        {
            //Arrange
            var controller = new SkoAdminController(new SkoBLL(new DbSkoStub()));
            var forventetResultat = new List<SkoListeElement>
            {
                new SkoListeElement
                    {
                        skoId = 1,
                        navn = "B&CO 2455100311",
                        merke = "B&CO",
                        forHvem = "Dame",
                        kategori = "Sko"
                    },
                new SkoListeElement
                    {
                        skoId = 2,
                        navn = "Sanita 538665",
                        merke = "Sanita",
                        forHvem = "Herre",
                        kategori = "Gummistøvler"
                    },
                new SkoListeElement
                    {
                        skoId = 3,
                        navn = "92-98024",
                        merke = "Duffy",
                        forHvem = "Dame",
                        kategori = "Gummistøvler"
                    }
            };

            //Act
            var resultat = (PartialViewResult)controller.SkoListe();
            var resultatListe = (List<SkoListeElement>)resultat.Model;

            //Assert
            Assert.AreEqual(resultat.ViewName, "");
            for (var i = 0; i < resultatListe.Count; ++i)
            {
                Assert.AreEqual(forventetResultat[i].skoId, resultatListe[i].skoId);
                Assert.AreEqual(forventetResultat[i].navn, resultatListe[i].navn);
                Assert.AreEqual(forventetResultat[i].merke, resultatListe[i].merke);
                Assert.AreEqual(forventetResultat[i].forHvem, resultatListe[i].forHvem);
                Assert.AreEqual(forventetResultat[i].kategori, resultatListe[i].kategori);
            }
        }

        [TestMethod]
        public void SlettedeSkoListe_vis_view()
        {
            //Arrange
            var controller = new SkoAdminController(new SkoBLL(new DbSkoStub()));
            var forventetResultat = new List<SkoListeElement>
            {
                new SkoListeElement
                    {
                        skoId = 1,
                        navn = "B&CO 2455100311",
                        merke = "B&CO",
                        forHvem = "Dame",
                        kategori = "Sko"
                    },
                new SkoListeElement
                    {
                        skoId = 2,
                        navn = "Sanita 538665",
                        merke = "Sanita",
                        forHvem = "Herre",
                        kategori = "Gummistøvler"
                    },
                new SkoListeElement
                    {
                        skoId = 3,
                        navn = "92-98024",
                        merke = "Duffy",
                        forHvem = "Dame",
                        kategori = "Gummistøvler"
                    }
            };

            //Act
            var resultat = (PartialViewResult)controller.SlettedeSkoListe();
            var resultatListe = (List<SkoListeElement>)resultat.Model;

            //Assert
            Assert.AreEqual(resultat.ViewName, "");
            for (var i = 0; i < resultatListe.Count; ++i)
            {
                Assert.AreEqual(forventetResultat[i].skoId, resultatListe[i].skoId);
                Assert.AreEqual(forventetResultat[i].navn, resultatListe[i].navn);
                Assert.AreEqual(forventetResultat[i].merke, resultatListe[i].merke);
                Assert.AreEqual(forventetResultat[i].forHvem, resultatListe[i].forHvem);
                Assert.AreEqual(forventetResultat[i].kategori, resultatListe[i].kategori);
            }
        }

        [TestMethod]
        public void Detaljer_Ok_get()
        {
            //Arrange
            var controller = new SkoAdminController(new SkoBLL(new DbSkoStub()));
            var forventetResultat = new Skoen
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

            //Act
            var resultat = (ViewResult)controller.Detaljer(1);
            var resultatListe = (Skoen)resultat.Model;

            //Assert
            Assert.AreEqual(resultat.ViewName, "");
            Assert.AreEqual(forventetResultat.skoId, resultatListe.skoId);
            Assert.AreEqual(forventetResultat.navn, resultatListe.navn);
            Assert.AreEqual(forventetResultat.merke, resultatListe.merke);
            Assert.AreEqual(forventetResultat.forHvem, resultatListe.forHvem);
            Assert.AreEqual(forventetResultat.kategori, resultatListe.kategori);
            Assert.AreEqual(forventetResultat.farge, resultatListe.farge);
            Assert.AreEqual(forventetResultat.beskrivelse, resultatListe.beskrivelse);
            Assert.AreEqual(forventetResultat.pris, resultatListe.pris);
            for (var i = 0; i < resultatListe.bilder.Count; ++i) { 
                Assert.AreEqual(forventetResultat.bilder[i].bildeId, resultatListe.bilder[i].bildeId);
                Assert.AreEqual(forventetResultat.bilder[i].bildeUrl, resultatListe.bilder[i].bildeUrl);
            }
            for (var i = 0; i < resultatListe.storlekar.Count; ++i)
            {
                Assert.AreEqual(forventetResultat.storlekar[i].storlekId, resultatListe.storlekar[i].storlekId);
                Assert.AreEqual(forventetResultat.storlekar[i].storlek, resultatListe.storlekar[i].storlek);
                Assert.AreEqual(forventetResultat.storlekar[i].antall, resultatListe.storlekar[i].antall);
            }
        }

        [TestMethod]
        public void Detaljer_Feil_Db_get()
        {
            //Arrange
            var controller = new SkoAdminController(new SkoBLL(new DbSkoStub()));
            
            //Act
            var resultat = (ViewResult)controller.Detaljer(0);
            var resultatListe = (Skoen)resultat.Model;

            //Assert
            Assert.AreEqual(resultat.ViewName, "");
            Assert.AreEqual(null, resultatListe);
            
        }

        [TestMethod]
        public void Prishistorikk_Ok_get()
        {
            //Arrange
            var controller = new SkoAdminController(new SkoBLL(new DbSkoStub()));
            var forventetResultat = new List<Pris>
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
            //Act
            var resultat = (PartialViewResult)controller.Prishistorikk(1);
            var resultatListe = (List<Pris>)resultat.Model;

            //Assert
            Assert.AreEqual(resultat.ViewName, "");
            for (var i = 0; i < resultatListe.Count; ++i)
            {
                Assert.AreEqual(forventetResultat[i].skoId, resultatListe[i].skoId);
                Assert.AreEqual(forventetResultat[i].skoNavn, resultatListe[i].skoNavn);
                Assert.AreEqual(forventetResultat[i].dato, resultatListe[i].dato);
                Assert.AreEqual(forventetResultat[i].pris, resultatListe[i].pris);
            }
        }

        [TestMethod]
        public void Prishistorikk_Feil_Db_get()
        {
            //Arrange
            var controller = new SkoAdminController(new SkoBLL(new DbSkoStub()));

            //Act
            var resultat = (PartialViewResult)controller.Prishistorikk(0);
            var resultatListe = (List<Pris>)resultat.Model;

            //Assert
            Assert.AreEqual(resultat.ViewName, "");
            Assert.AreEqual(null, resultatListe);

        }
    }
}
