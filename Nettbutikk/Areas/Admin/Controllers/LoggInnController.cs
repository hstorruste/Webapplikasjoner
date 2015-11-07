using BLL.Admin;
using Model.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nettbutikk.Areas.Admin.Controllers
{
    public class LoggInnController : Controller
    {
        ILoggInnLogikk _LoggInnBLL;

        public LoggInnController()
        {
            _LoggInnBLL = new LoggInnBLL();
        }
       
        public ActionResult LoggInn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoggInn(LoggInn innAdmin)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (_LoggInnBLL.adminIDb(innAdmin))
            {
                Session["AdminLoggetInn"] = true;
                
                return RedirectToAction("Hjem", "Admin", new { area = "Admin" });
                
            }
            else
            {
                Session["AdminLoggetInn"] = false;
                ViewData["AdminFeilPassord"] = "Feil brukernavn eller passord!";
                return View();
            }
        }

        public ActionResult LoggUt()
        {
            Session["AdminLoggetInn"] = false;
            
            return RedirectToAction("Hjem", "NettButikk", new { area = "" });
        }
    }
}