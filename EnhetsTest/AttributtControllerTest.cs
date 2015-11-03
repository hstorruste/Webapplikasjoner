using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nettbutikk.Areas.Admin.Controllers;
using Admin.BLL;
using Admin.DAL;
using Nettbutikk.Model;
using System.Web.Mvc;
using System.Collections.Generic;
using Microsoft.CSharp;

namespace EnhetsTest
{
    [TestClass]
    public class AttributtControllerTest
    {
        [TestMethod]
        public void Index_vis_view()
        {
            //Arrange
            var controller = new AttributtController(new AttributtBLL(new DbAttributterStub()));

            //Act
            var resultat = (ViewResult)controller.Index();

            //Assert
            Assert.AreEqual(resultat.ViewName, "");
        }

        [TestMethod]
        public void ListeFor_vis_view()
        {
            //Arrange
            var controller = new AttributtController(new AttributtBLL(new DbAttributterStub()));
            var forventetResultat = new List<ForHvem>
            {
                new ForHvem { forId = 1, navn = "Herre", antallSko = 1 },
                new ForHvem { forId = 2, navn = "Dame", antallSko = 2 },
                new ForHvem { forId = 3, navn = "Barn", antallSko = 3 }
            };
            //Act
            var resultat = (PartialViewResult)controller.ListeFor();
            var resultatListe = (List<ForHvem>)resultat.Model;
            //Assert
            Assert.AreEqual(resultat.ViewName, "");
            for( var i=0; i < resultatListe.Count; ++i )
            {
                Assert.AreEqual(forventetResultat[i].forId, resultatListe[i].forId);
                Assert.AreEqual(forventetResultat[i].navn, resultatListe[i].navn);
                Assert.AreEqual(forventetResultat[i].antallSko, resultatListe[i].antallSko);
            }
        }

        [TestMethod]
        public void ListeKategorier_vis_view()
        {
            //Arrange
            var controller = new AttributtController(new AttributtBLL(new DbAttributterStub()));
            var forventetResultat = new List<Kategori>
            {
                new Kategori { kategoriId = 1, navn = "Sko", antallSko = 1 },
                new Kategori { kategoriId = 2, navn = "Sneakers", antallSko = 2 },
                new Kategori { kategoriId = 3, navn = "Gummistøvler", antallSko = 3 }
            };
            //Act
            var resultat = (PartialViewResult)controller.ListeKategorier();
            var resultatListe = (List<Kategori>)resultat.Model;
            //Assert
            Assert.AreEqual(resultat.ViewName, "");
            for (var i = 0; i < resultatListe.Count; ++i)
            {
                Assert.AreEqual(forventetResultat[i].kategoriId, resultatListe[i].kategoriId);
                Assert.AreEqual(forventetResultat[i].navn, resultatListe[i].navn);
                Assert.AreEqual(forventetResultat[i].antallSko, resultatListe[i].antallSko);
            }
        }

        [TestMethod]
        public void ListeMerker_vis_view()
        {
            //Arrange
            var controller = new AttributtController(new AttributtBLL(new DbAttributterStub()));
            var forventetResultat = new List<Merke>
            {
                new Merke { merkeId = 1, navn = "Odiin", antallSko = 1 },
                new Merke { merkeId = 2, navn = "B&CO", antallSko = 2 },
                new Merke { merkeId = 3, navn = "Sanita", antallSko = 3 }
            };
            //Act
            var resultat = (PartialViewResult)controller.ListeMerker();
            var resultatListe = (List<Merke>)resultat.Model;
            //Assert
            Assert.AreEqual(resultat.ViewName, "");
            for (var i = 0; i < resultatListe.Count; ++i)
            {
                Assert.AreEqual(forventetResultat[i].merkeId, resultatListe[i].merkeId);
                Assert.AreEqual(forventetResultat[i].navn, resultatListe[i].navn);
                Assert.AreEqual(forventetResultat[i].antallSko, resultatListe[i].antallSko);
            }
        }

        [TestMethod]
        public void LeggTilFor_Ok_Post()
        {
            //Arrange
            var controller = new AttributtController(new AttributtBLL(new DbAttributterStub()));
            var forventetResultat = new ForHvem
            {
                forId = 1,
                navn = "Herre"
            };
            //Act
            var resultat = (JsonResult)controller.LeggTilFor(new ForHvem { navn = "Herre" });
            dynamic jsonObject = resultat.Data;
            
            //Assert
            Assert.AreEqual(forventetResultat.forId, jsonObject.forId);
            Assert.AreEqual(forventetResultat.navn, jsonObject.navn);
        }

        [TestMethod]
        public void LeggTilFor_Feil_Db_Post()
        {
            //Arrange
            var controller = new AttributtController(new AttributtBLL(new DbAttributterStub()));

            //Act
            var resultat = (JsonResult)controller.LeggTilFor(new ForHvem { navn = "" });
            dynamic jsonObject = resultat.Data;

            //Assert
            Assert.AreEqual(null,jsonObject);
        }

        [TestMethod]
        public void LeggTilKategori_Ok_Post()
        {
            //Arrange
            var controller = new AttributtController(new AttributtBLL(new DbAttributterStub()));
            var forventetResultat = new Kategori
            {
                kategoriId = 1,
                navn = "Sko"
            };
            //Act
            var resultat = (JsonResult)controller.LeggTilKategori(new Kategori { navn = "Sko" });
            dynamic jsonObject = resultat.Data;

            //Assert
            Assert.AreEqual(forventetResultat.kategoriId, jsonObject.kategoriId);
            Assert.AreEqual(forventetResultat.navn, jsonObject.navn);
        }

        [TestMethod]
        public void LeggTilKategori_Feil_Db_Post()
        {
            //Arrange
            var controller = new AttributtController(new AttributtBLL(new DbAttributterStub()));

            //Act
            var resultat = (JsonResult)controller.LeggTilKategori(new Kategori { navn = "" });
            dynamic jsonObject = resultat.Data;

            //Assert
            Assert.AreEqual(null, jsonObject);
        }

        [TestMethod]
        public void LeggTilMerke_Ok_Post()
        {
            //Arrange
            var controller = new AttributtController(new AttributtBLL(new DbAttributterStub()));
            var forventetResultat = new Merke
            {
                merkeId = 1,
                navn = "Adidas"
            };
            //Act
            var resultat = (JsonResult)controller.LeggTilMerke(new Merke { navn = "Adidas" });
            dynamic jsonObject = resultat.Data;

            //Assert
            Assert.AreEqual(forventetResultat.merkeId, jsonObject.merkeId);
            Assert.AreEqual(forventetResultat.navn, jsonObject.navn);
        }

        [TestMethod]
        public void LeggTilMerke_Feil_Db_Post()
        {
            //Arrange
            var controller = new AttributtController(new AttributtBLL(new DbAttributterStub()));

            //Act
            var resultat = (JsonResult)controller.LeggTilMerke(new Merke { navn = "" });
            dynamic jsonObject = resultat.Data;

            //Assert
            Assert.AreEqual(null, jsonObject);
        }

        [TestMethod]
        public void OppdaterMerke_Ok_Post()
        {
            //Arrange
            var controller = new AttributtController(new AttributtBLL(new DbAttributterStub()));
            var forventetResultat = new Merke
            {
                merkeId = 1,
                navn = "Adidas"
            };
            //Act
            var resultat = (JsonResult)controller.OppdaterMerke(forventetResultat);
            dynamic jsonObject = resultat.Data;

            //Assert
            Assert.AreEqual(forventetResultat.merkeId, jsonObject.merkeId);
            Assert.AreEqual(forventetResultat.navn, jsonObject.navn);
        }

        [TestMethod]
        public void OppdaterMerke_Feil_Db_Post()
        {
            //Arrange
            var controller = new AttributtController(new AttributtBLL(new DbAttributterStub()));

            //Act
            var resultat = (JsonResult)controller.OppdaterMerke(new Merke { navn = "" });
            dynamic jsonObject = resultat.Data;

            //Assert
            Assert.AreEqual(null, jsonObject);
        }

        [TestMethod]
        public void OppdaterKategori_Ok_Post()
        {
            //Arrange
            var controller = new AttributtController(new AttributtBLL(new DbAttributterStub()));
            var forventetResultat = new Kategori
            {
                kategoriId = 1,
                navn = "Sko"
            };
            //Act
            var resultat = (JsonResult)controller.OppdaterKategori(forventetResultat);
            dynamic jsonObject = resultat.Data;

            //Assert
            Assert.AreEqual(forventetResultat.kategoriId, jsonObject.kategoriId);
            Assert.AreEqual(forventetResultat.navn, jsonObject.navn);
        }

        [TestMethod]
        public void OppdaterKategori_Feil_Db_Post()
        {
            //Arrange
            var controller = new AttributtController(new AttributtBLL(new DbAttributterStub()));

            //Act
            var resultat = (JsonResult)controller.OppdaterKategori(new Kategori { navn = "" });
            dynamic jsonObject = resultat.Data;

            //Assert
            Assert.AreEqual(null, jsonObject);
        }

        [TestMethod]
        public void OppdaterFor_Ok_Post()
        {
            //Arrange
            var controller = new AttributtController(new AttributtBLL(new DbAttributterStub()));
            var forventetResultat = new ForHvem
            {
                forId = 1,
                navn = "Herre"
            };
            //Act
            var resultat = (JsonResult)controller.OppdaterFor(forventetResultat);
            dynamic jsonObject = resultat.Data;

            //Assert
            Assert.AreEqual(forventetResultat.forId, jsonObject.forId);
            Assert.AreEqual(forventetResultat.navn, jsonObject.navn);
        }

        [TestMethod]
        public void OppdaterFor_Feil_Db_Post()
        {
            //Arrange
            var controller = new AttributtController(new AttributtBLL(new DbAttributterStub()));

            //Act
            var resultat = (JsonResult)controller.OppdaterFor(new ForHvem { navn = "" });
            dynamic jsonObject = resultat.Data;

            //Assert
            Assert.AreEqual(null, jsonObject);
        }

        [TestMethod]
        public void SlettMerke_Ok_Post()
        {
            //Arrange
            var controller = new AttributtController(new AttributtBLL(new DbAttributterStub()));
            var forventetResultat = new Merke
            {
                merkeId = 1,
                navn = "Adidas"
            };
            //Act
            var resultat = (JsonResult)controller.SlettMerke(1);
            dynamic jsonObject = resultat.Data;

            //Assert
            Assert.AreEqual(forventetResultat.merkeId, jsonObject.merkeId);
            Assert.AreEqual(forventetResultat.navn, jsonObject.navn);
        }

        [TestMethod]
        public void SlettMerke_Feil_Db_Post()
        {
            //Arrange
            var controller = new AttributtController(new AttributtBLL(new DbAttributterStub()));

            //Act
            var resultat = (JsonResult)controller.SlettMerke(0);
            dynamic jsonObject = resultat.Data;

            //Assert
            Assert.AreEqual(null, jsonObject);
        }

        [TestMethod]
        public void SlettKategori_Ok_Post()
        {
            //Arrange
            var controller = new AttributtController(new AttributtBLL(new DbAttributterStub()));
            var forventetResultat = new Kategori
            {
                kategoriId = 1,
                navn = "Sko"
            };
            //Act
            var resultat = (JsonResult)controller.SlettKategori(1);
            dynamic jsonObject = resultat.Data;

            //Assert
            Assert.AreEqual(forventetResultat.kategoriId, jsonObject.kategoriId);
            Assert.AreEqual(forventetResultat.navn, jsonObject.navn);
        }

        [TestMethod]
        public void SlettKategori_Feil_Db_Post()
        {
            //Arrange
            var controller = new AttributtController(new AttributtBLL(new DbAttributterStub()));

            //Act
            var resultat = (JsonResult)controller.SlettKategori(0);
            dynamic jsonObject = resultat.Data;

            //Assert
            Assert.AreEqual(null, jsonObject);
        }

        [TestMethod]
        public void SlettFor_Ok_Post()
        {
            //Arrange
            var controller = new AttributtController(new AttributtBLL(new DbAttributterStub()));
            var forventetResultat = new ForHvem
            {
                forId = 1,
                navn = "Herre"
            };
            //Act
            var resultat = (JsonResult)controller.SlettFor(1);
            dynamic jsonObject = resultat.Data;

            //Assert
            Assert.AreEqual(forventetResultat.forId, jsonObject.forId);
            Assert.AreEqual(forventetResultat.navn, jsonObject.navn);
        }

        [TestMethod]
        public void SlettFor_Feil_Db_Post()
        {
            //Arrange
            var controller = new AttributtController(new AttributtBLL(new DbAttributterStub()));

            //Act
            var resultat = (JsonResult)controller.SlettFor(0);
            dynamic jsonObject = resultat.Data;

            //Assert
            Assert.AreEqual(null, jsonObject);
        }
    }
}
