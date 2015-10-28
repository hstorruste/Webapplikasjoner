using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nettbutikk.Model;
using BLL;

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
                Kunder kunde = _kunderBLL.getKunde(innKunde.epost);    
            
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
                Kunder kunde = _kunderBLL.getKunde(innKunde.epost);

                Session["Kundenavn"] = kunde.Fornavn + " " + kunde.Etternavn;
                Session["InnloggetKundeId"] = kunde.Id;
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
                Kunder kunde = _kunderBLL.getKunde(innKunde.Epost);

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
            var tempOrdre = _kunderBLL.getOrdre(ordreId);

            var ordre = new Ordre()
            {
                ordreId = tempOrdre.OrdreId,
                ordreDato = tempOrdre.OrdreDato,
                kundeId = tempOrdre.KundeId,
                kundeNavn = tempOrdre.Kunder.Fornavn + " " + tempOrdre.Kunder.Etternavn,
                adresse = tempOrdre.Kunder.Adresse,
                postnr = tempOrdre.Kunder.Postnr,
                poststed = tempOrdre.Kunder.Poststeder.Poststed,
                varer = tempOrdre.OrdreDetaljer.Select(d => new HandlevognVare
                {
                    skoId = d.Sko.SkoId,
                    skoNavn = d.Sko.Navn,
                    merke = d.Sko.Merke.Navn,
                    farge = d.Sko.Farge,
                    storlek = d.Storlek,
                    pris = d.Pris,
                    bildeUrl = d.Sko.Bilder.Where(b => b.BildeUrl.Contains("/Medium/")).FirstOrDefault().BildeUrl,
                }).ToList(),
                totalBelop = tempOrdre.TotalBelop
            };

            return PartialView("OrdreDetaljerKunde", ordre);
        }
    }
}