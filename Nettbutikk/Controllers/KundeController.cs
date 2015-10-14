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
                using (var db = new NettbutikkContext())
                {
                    Kunder kunde = db.Kunder.FirstOrDefault(k => k.Epost == innKunde.epost);
                    Session["Kundenavn"] = kunde.Fornavn + " " + kunde.Etternavn;
                    Session["InnloggetKundeId"] = kunde.Id;
                };
                ViewBag.innLogget = true;
                Session["LoggetInn"] = true;
                Session["EmailFinnes"] = false;
                return RedirectToAction("Hjem","Nettbutikk");
            }
            else
            {
                Session["EmailFinnes"] = true;
                return View();
            }
        }

        public ActionResult RedigerKunde(int id)
        {
            RedigerKundeModell enKunde = DbKunder.hentEnKunde(id);

            return View(enKunde);  
        }

       [HttpPost]
        public ActionResult RedigerKunde(RedigerKundeModell innKunde)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (DbKunder.redigerKunde(innKunde))
            {
                using (var db = new NettbutikkContext())
                {
                    Kunder kunde = db.Kunder.FirstOrDefault(k => k.Epost == innKunde.epost);
                    Session["Kundenavn"] = kunde.Fornavn + " " + kunde.Etternavn;
                    Session["InnloggetKundeId"] = kunde.Id;
                };
                ViewBag.innLogget = true;
                Session["LoggetInn"] = true;
                return RedirectToAction("Hjem", "Nettbutikk");
            }
            else
            {
                return View();
            }
        }

        public ActionResult RedigerKundePassord(int PassordId)
        {
            return View();
        }

        [HttpPost]
        public ActionResult RedigerKundePassord(RedigerKundePassordModell innPassord)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (DbKunder.redigerKundePassord(innPassord))
            {
                using (var db = new NettbutikkContext())
                {
                    Passorden passord = db.Passorden.FirstOrDefault(p => p.PassordId == innPassord.PassordId);
                    Session["InnloggetKundePassordId"] = passord.PassordId;
                };
                ViewBag.innLogget = true;
                Session["LoggetInn"] = true;
                return RedirectToAction("Hjem", "Nettbutikk");
            }
            else
            {
                return View();
            }
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
                    Session["Kundenavn"] = kunde.Fornavn + " " + kunde.Etternavn;
                    Session["InnloggetKundeId"] = kunde.Id;
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
    }
}