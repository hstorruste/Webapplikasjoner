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
                Kunder kunde = DbKunder.getKunde(innKunde.epost);    
            
                Session["Kundenavn"] = kunde.Fornavn + " " + kunde.Etternavn;
                Session["InnloggetKundeId"] = kunde.Id;
                Session["InnloggetKundePassordId"] = kunde.Passorden.PassordId;
                ViewBag.innLogget = true;
                Session["LoggetInn"] = true;
                Session["EmailFinnes"] = false;
                if (Session["fraBetaling"] != null && (bool)Session["fraBetaling"] == true)
                {
                    return RedirectToAction("Betaling", "Handlevogn");
                }
                else
                {
                    return RedirectToAction("Hjem", "Nettbutikk");
                }
            }
            else
            {
                Session["EmailFinnes"] = true;
                return View();
            }
        }

        [ChildActionOnly]
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
                return PartialView();
            }
            if (DbKunder.redigerKunde(innKunde))
            {
                Kunder kunde = DbKunder.getKunde(innKunde.epost);

                Session["Kundenavn"] = kunde.Fornavn + " " + kunde.Etternavn;
                Session["InnloggetKundeId"] = kunde.Id;
                ViewBag.innLogget = true;
                Session["LoggetInn"] = true;
                Session["EmailFinnes"] = false;
                return PartialView();
            }
            else
            {
                Session["EmailFinnes"] = true;
                return PartialView();
            }
        }

        [ChildActionOnly]
        public ActionResult RedigerKundePassord(int passordId)
        {
            RedigerKundePassordModell enKundePassord = DbKunder.hentEnKundePassord(passordId);

            return PartialView(enKundePassord);
        }

        [HttpPost]
        public int RedigerKundePassord(RedigerKundePassordModell innPassord)
        {
            if (!ModelState.IsValid)
            {
                return 0;
            }
            if (DbKunder.redigerKundePassord(innPassord))
            {
                Passorden passord = DbKunder.getKundePassord(innPassord.passordId);
                Session["InnloggetKundePassordId"] = passord.PassordId;
                ViewBag.innLogget = true;
                Session["LoggetInn"] = true;
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public ActionResult seAlleKundeOrdre(int id)
        {
            var kundeOrdre = DbHandlevogn.finnAlleOrdre(id);
            return View(kundeOrdre);
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
                Kunder kunde = DbKunder.getKunde(innKunde.Epost);

                Session["Kundenavn"] = kunde.Fornavn + " " + kunde.Etternavn;
                Session["InnloggetKundeId"] = kunde.Id;
                Session["InnloggetKundePassordId"] = kunde.Passorden.PassordId;
                Session["LoggetInn"] = true;
                ViewBag.Innlogget = true;

                if (Session["fraBetaling"] != null && (bool)Session["fraBetaling"] == true)
                {
                    return RedirectToAction("Betaling", "Handlevogn");
                }
                else
                {
                    return RedirectToAction("Hjem", "Nettbutikk");
                }
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

        public ActionResult DetaljerKunde()
        {
            if(Session["LoggetInn"] == null || !(bool)Session["LoggetInn"])
            {
                return RedirectToAction("Hjem", "NettButikk");
            } 
            return View();
        }
    }
}