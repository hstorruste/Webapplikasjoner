using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nettbutikk.Models;

namespace Nettbutikk.Controllers
{
    public class HandlevognController : Controller
    {
        // GET: Handlevogn
        public ActionResult Index()
        {
            var handlevogn = DbHandlevogn.getHandlevogn(Session.SessionID);
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
            var tempOrdre = DbHandlevogn.lagOrdre(Session.SessionID, kundeId); //Ny ordre ikke ennå lagret i databasen.
            var ordre = new Ordre() {
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
            
            return View(ordre);
        }

        //Partial view
        public ActionResult OrdreVarer(Ordre ordre)
        {
            return View(ordre);
        }

        public ActionResult Kvittering()
        {
            if (Session["LoggetInn"] == null || !(bool)Session["LoggetInn"])
            {
                return RedirectToAction("LoggInnKunde", "Kunde");
            }
            var kundeId = (int)Session["InnloggetKundeId"];

            var sisteOrdre = DbHandlevogn.finnSisteOrdre(kundeId);
            var ordre = new Ordre()
            {
                ordreId = sisteOrdre.OrdreId,
                ordreDato = sisteOrdre.OrdreDato,
                kundeId = sisteOrdre.KundeId,
                kundeNavn = sisteOrdre.Kunder.Fornavn + " " + sisteOrdre.Kunder.Etternavn,
                adresse = sisteOrdre.Kunder.Adresse,
                postnr = sisteOrdre.Kunder.Postnr,
                poststed = sisteOrdre.Kunder.Poststeder.Poststed,
                varer = sisteOrdre.OrdreDetaljer.Select(d => new HandlevognVare
                {
                    skoId = d.Sko.SkoId,
                    skoNavn = d.Sko.Navn,
                    merke = d.Sko.Merke.Navn,
                    farge = d.Sko.Farge,
                    storlek = d.Storlek,
                    pris = d.Pris,
                    bildeUrl = d.Sko.Bilder.Where(b => b.BildeUrl.Contains("/Medium/")).FirstOrDefault().BildeUrl,
                }).ToList(),
                totalBelop = sisteOrdre.TotalBelop
            };

            return View(ordre);
        }

        //Kalles med ajax fra Handlevogn/Betaling-View
        public bool SendOrdre()
        {
            if (Session["LoggetInn"] == null || !(bool)Session["LoggetInn"])
                return false;

            var kundeId = (int)Session["InnloggetKundeId"];
            var nyOrdre = DbHandlevogn.lagOrdre(Session.SessionID, kundeId);
            var ok = DbHandlevogn.arkiverOrdre(nyOrdre);
           
            return ok;
        }

        //Kalles med ajax fra Handlevogn/Kvittering-View
        public bool SlettHandlevognVarer()
        {
            return DbHandlevogn.slettAlleHandlevognVarer(Session.SessionID);
        }

        //Kalles med ajax fra Sko/Detaljer-View
        public bool LeggTil(int skoId, int skoStr)
        {
            Kundevogner nyVare = new Kundevogner()
            {
                SessionId = Session.SessionID,
                Dato = DateTime.Now,
                SkoId = skoId,
                Storlek = skoStr
            };
            return DbHandlevogn.leggTilVare(nyVare);
        }

        //Kalles med ajax fra Handlevogn/Index-View
        public bool FjernVare(int vareId)
        {
            return DbHandlevogn.fjernVare(vareId);
        }
    }
}