using BLL.Admin;
using DAL.Admin;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Nettbutikk;
using MvcContrib.TestHelper;
using Nettbutikk.Areas.Admin.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EnhetsTest
{
    [TestClass]
    public class KundeAdminControllerTest
    {
        [TestMethod]
        public void Index_Ok_vis_view()
        {
            //Arrange
            var controller = new KundeAdminController(new KundeBLL(new DbKunderStub()));
            var SessionMock = new TestControllerBuilder();
            SessionMock.InitializeController(controller);
            controller.Session["AdminLoggetInn"] = true;
            //Act
            var resultat = (ViewResult)controller.Index();

            //Assert
            Assert.AreEqual(resultat.ViewName, "");
        }

        [TestMethod]
        public void Index_feil_ikke_logget_inn()
        {
            //Arrange
            var controller = new KundeAdminController(new KundeBLL(new DbKunderStub()));
            var SessionMock = new TestControllerBuilder();
            SessionMock.InitializeController(controller);
            controller.Session["AdminLoggetInn"] = false;
            //Act
            var resultat = (RedirectToRouteResult)controller.Index();

            //Assert
            Assert.AreEqual(resultat.RouteName, "");
            Assert.AreEqual(resultat.RouteValues.Values.Last(), "Nettbutikk");
        }

        [TestMethod]
        public void Index_feil_logget_inn_undefined()
        {
            //Arrange
            var controller = new KundeAdminController(new KundeBLL(new DbKunderStub()));
            var SessionMock = new TestControllerBuilder();
            SessionMock.InitializeController(controller);
            //Act
            var resultat = (RedirectToRouteResult)controller.Index();

            //Assert
            Assert.AreEqual(resultat.RouteName, "");
            Assert.AreEqual(resultat.RouteValues.Values.Last(), "Nettbutikk");
        }

        [TestMethod]
        public void SkoListe_vis_view()
        {
            //Arrange
            var controller = new KundeAdminController(new KundeBLL(new DbKunderStub()));
            var forventetResultat = new List<Kunde>
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
            //Act
            var resultat = (PartialViewResult)controller.KundeListe();
            var resultatListe = (List<Kunde>)resultat.Model;
            //Assert
            Assert.AreEqual(resultat.ViewName, "");
            for (var i = 0; i < resultatListe.Count; ++i)
            {
                Assert.AreEqual(forventetResultat[i].id, resultatListe[i].id);
                Assert.AreEqual(forventetResultat[i].fornavn, resultatListe[i].fornavn);
                Assert.AreEqual(forventetResultat[i].etternavn, resultatListe[i].etternavn);
                Assert.AreEqual(forventetResultat[i].adresse, resultatListe[i].adresse);
                Assert.AreEqual(forventetResultat[i].postnr, resultatListe[i].postnr);
                Assert.AreEqual(forventetResultat[i].poststed, resultatListe[i].poststed);
                Assert.AreEqual(forventetResultat[i].epost, resultatListe[i].epost);
                Assert.AreEqual(forventetResultat[i].passordId, resultatListe[i].passordId);
            }
        }
    }
}
