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
    class LoggInnControllerTest
    {
        [TestMethod]
        public void LoggInn_ikke_ok()
        {
            //Arrange
            var controller = new LoggInnController(new LoggInnBLL(new DbLoggInnStub()));
            var SessionMock = new TestControllerBuilder();
            SessionMock.InitializeController(controller);
            controller.Session["AdminLoggetInn"] = true;
            //Act
            var resultat = (ViewResult)controller.LoggInn();

            //Assert
            Assert.AreEqual(resultat.ViewName, "");
        }

        [TestMethod]
        public void Logg_feil_ikke_logget_inn()
        {
            //Arrange
            var controller = new AttributtController(new AttributtBLL(new DbAttributterStub()));
            var SessionMock = new TestControllerBuilder();
            SessionMock.InitializeController(controller);
            //Act
            var resultat = (RedirectToRouteResult)controller.Index();

            //Assert
            Assert.AreEqual(resultat.RouteName, "");
            Assert.AreEqual(resultat.RouteValues.Values.Last(), "Admin");
        }
    }
}
