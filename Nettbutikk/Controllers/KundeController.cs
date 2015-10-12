using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nettbutikk.Models;

namespace Nettbutikk.Controllers
{
    public class KundeController : Controller
    {
        public ActionResult RegistrerKunde()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegistrerKunde(RegistrerKundeModell innKunde)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (DbKunder.registrerKunde(innKunde))
            {
                ViewBag.innLogget = true;
                Session["LoggetInn"] = true;
                return RedirectToAction("Hjem","Nettbutikk");
            }
            else
            {
                return View();
            }
        }

        public ActionResult RedigerKunde(int id)
        {
            RedigerKundeModell enKunde = DbKunder.hentEnKunde(id);

            return View(enKunde);  
        }

        public ActionResult LoggInnKunde()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoggInnKunde(LoggInnModell innKunde)
        {
            if (DbKunder.Kunde_i_DB(innKunde))
            {
                using (var db = new NettbutikkContext()) {
                    Kunder kunde = db.Kunder.FirstOrDefault(k => k.Epost == innKunde.Epost);
                    ViewBag.Kundenavn = kunde.Fornavn + " " + kunde.Etternavn;
                };
                Session["LoggetInn"] = true;
                ViewBag.Innlogget = true;
                return RedirectToAction("Hjem", "NettButikk");
            }
            else
            {
                Session["LoggetInn"] = false;
                ViewBag.Innlogget = false;
                return View();
            }
        }

        public ActionResult LoggUtKunde()
        {
            Session["LoggetInn"] = false;
            ViewBag.Innlogget = false;

            return RedirectToAction("Hjem","NettButikk");
        }

        public ActionResult InnLogetSide()
        {
            if (Session["LoggetInn"] != null)
            {
                bool loggetInn = (bool)Session["LoggetInn"];
                if (loggetInn)
                {
                    return View();
                }
            }
            return RedirectToAction("LoggInn");
        }
    }
}