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
            if (!(bool)Session["LoggetInn"])
            {
                return RedirectToAction("LoggInnKunde", "Kunde"); //Må finne en måte å returnere til betaling etter man er logget inn eller registrert.
            }
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
            
            //TODO - Må lage ett view som mottar en Ordre.
            return View(ordre);
        }

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

        public bool FjernVare(int vareId)
        {
            return DbHandlevogn.fjernVare(vareId);
        }
    }
}