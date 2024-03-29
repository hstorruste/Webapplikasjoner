﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Nettbutikk;
using BLL.Nettbutikk;

namespace Nettbutikk.Controllers
{
    public class HandlevognController : Controller
    {
        IHandlevognLogikk _handlevognBLL;
        IKundeLogikk _kunderBLL;

        public HandlevognController()
        {
            _handlevognBLL = new HandlevognBLL();
            _kunderBLL = new KunderBLL();
        }

        public ActionResult Index()
        {
            var handlevogn = _handlevognBLL.getHandlevogn(Session.SessionID);
            return View(handlevogn);
        }

        public ActionResult Betaling()
        {
            if (Session["LoggetInn"] == null || !(bool)Session["LoggetInn"])
            {
                Session["FraBetaling"] = true;
                return RedirectToAction("LoggInnKunde", "Kunde"); //Må finne en måte å returnere til betaling etter man er logget inn eller registrert.
            }
            Session["FraBetaling"] = false;
            var kundeId = (int) Session["InnloggetKundeId"];
            var ordre = _handlevognBLL.lagTempOrdre(Session.SessionID, kundeId); //Ny ordre ikke ennå lagret i databasen.
            return View(ordre);
        }

        //Partial view
        public ActionResult OrdreVarer(Ordre ordre)
        {
            return PartialView(ordre);
        }

        public ActionResult Kvittering()
        {
            if (Session["LoggetInn"] == null || !(bool)Session["LoggetInn"])
            {
                return RedirectToAction("LoggInnKunde", "Kunde");
            }
            var kundeId = (int)Session["InnloggetKundeId"];

            var sisteOrdre = _kunderBLL.finnSisteOrdre(kundeId);
            return View(sisteOrdre);
        }

        [ChildActionOnly]
        public ActionResult AntallVarer()
        {
            ViewData["VareAntall"] = _handlevognBLL.antallHandlevognVarer(Session.SessionID);
            return PartialView("AntallVarer");
        }

        //Kalles med ajax fra Handlevogn/Betaling-View
        public bool SendOrdre()
        {
            if (Session["LoggetInn"] == null || !(bool)Session["LoggetInn"])
                return false;

            var kundeId = (int)Session["InnloggetKundeId"];
            var ok = _kunderBLL.arkiverOrdre(Session.SessionID, kundeId);
           
            return ok;
        }

        //Kalles med ajax fra Handlevogn/Kvittering-View
        public bool SlettHandlevognVarer()
        {
            return _handlevognBLL.slettAlleHandlevognVarer(Session.SessionID);
        }

        //Kalles med ajax fra Sko/Detaljer-View
        public bool LeggTil(int skoId, int skoStr)
        {
            return _handlevognBLL.leggTilVare(Session.SessionID, skoId, skoStr);
        }

        //Kalles med ajax fra Handlevogn/Index-View
        public bool FjernVare(int vareId)
        {
            return _handlevognBLL.fjernVare(vareId);
        }
    }
}