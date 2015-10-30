using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Nettbutikk.BLL;

namespace Nettbutikk
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var init = new InitializerBLL();
            init.Initialize();

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
