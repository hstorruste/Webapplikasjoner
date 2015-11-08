using BLL.Admin;
using DAL.Admin;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    class OrdreControllerTest
    {
        [TestMethod]
        public void Index_Ok_vis_view()
        {
            //Arrange
            var controller = new OrdreController(new OrdreBLL(new DbOrdrerStub()));
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
            var controller = new OrdreController(new OrdreBLL(new DbOrdrerStub()));
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
            var controller = new OrdreController(new OrdreBLL(new DbOrdrerStub()));
            var SessionMock = new TestControllerBuilder();
            SessionMock.InitializeController(controller);
            //Act
            var resultat = (RedirectToRouteResult)controller.Index();

            //Assert
            Assert.AreEqual(resultat.RouteName, "");
            Assert.AreEqual(resultat.RouteValues.Values.Last(), "Nettbutikk");
        }
    }
}
