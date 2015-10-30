using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nettbutikk.Model;
using Nettbutikk.BLL;

namespace Nettbutikk.Controllers
{
    public class KundeController : Controller
    {
        IHandlevognLogikk _handlevognBLL;
        IKundeLogikk _kunderBLL;

        public KundeController()
        {
            _handlevognBLL = new HandlevognBLL();
            _kunderBLL = new KunderBLL();
        }
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
            if (_kunderBLL.registrerKunde(innKunde))
            {
                KundeModell kunde = _kunderBLL.getKunde(innKunde.epost);    
            
                Session["Kundenavn"] = kunde.fornavn + " " + kunde.etternavn;
                Session["InnloggetKundeId"] = kunde.id;
                Session["InnloggetKundePassordId"] = kunde.passordId;
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
            RedigerKundeModell enKunde = _kunderBLL.hentEnKunde(id);

            return PartialView(enKunde);  
        }

       [HttpPost]
        public ActionResult RedigerKunde(RedigerKundeModell innKunde)
        {
            if (!ModelState.IsValid)
            {
                return PartialView();
            }
            if (_kunderBLL.redigerKunde(innKunde))
            {
                KundeModell kunde = _kunderBLL.getKunde(innKunde.epost);

                Session["Kundenavn"] = kunde.fornavn + " " + kunde.etternavn;
                Session["InnloggetKundeId"] = kunde.id;
                Session["InnloggetKundePassordId"] = kunde.passordId;
                ViewBag.innLogget = true;
                Session["LoggetInn"] = true;
                ViewData["EmailFinnes"] = false;
                return PartialView();
            }
            else
            {
                ViewData["EmailFinnes"] = true;
                return PartialView();
            }
        }

        [ChildActionOnly]
        public ActionResult RedigerKundePassord(int passordId)
        {
            RedigerKundePassordModell enKundePassord = _kunderBLL.hentEnKundePassord(passordId);

            return PartialView(enKundePassord);
        }

        [HttpPost]
        public int RedigerKundePassord(RedigerKundePassordModell innPassord)
        {
            if (!ModelState.IsValid)
            {
                return 0;
            }
            if (_kunderBLL.redigerKundePassord(innPassord))
            {
                int passord = _kunderBLL.getKundePassord(innPassord.passordId);
                Session["InnloggetKundePassordId"] = passord;
                ViewBag.innLogget = true;
                Session["LoggetInn"] = true;
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public ActionResult OrdrehistorikkKunde(int id)
        {
            var kundeOrdre = _kunderBLL.finnAlleOrdre(id);
            return PartialView(kundeOrdre);
        }

        public ActionResult OrdreDetaljerKunde()
        {
            return PartialView();
        }

        public ActionResult LoggInnKunde()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoggInnKunde(LoggInnModell innKunde)
        {
            if (_kunderBLL.Kunde_i_DB(innKunde))
            {
                KundeModell kunde = _kunderBLL.getKunde(innKunde.Epost);

                Session["Kundenavn"] = kunde.fornavn + " " + kunde.etternavn;
                Session["InnloggetKundeId"] = kunde.id;
                Session["InnloggetKundePassordId"] = kunde.passordId;
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
                ViewData["FeilPassord"] = "Feil epost eller passord!";
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

        [HttpGet]
        public ActionResult getOrdreDetaljer(int ordreId)
        {
            var ordre = _kunderBLL.getOrdre(ordreId);

            return PartialView("OrdreDetaljerKunde", ordre);
        }
    }
}