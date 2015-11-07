using BLL.Admin;
using Model.Nettbutikk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nettbutikk.Areas.Admin.Controllers
{
    public class KundeAdminController : Controller
    {
        IKundeLogikk _kundeBLL;

        public KundeAdminController()
        {
            _kundeBLL = new KundeBLL();
        }

        public KundeAdminController(IKundeLogikk stub)
        {
            _kundeBLL = stub;
        }
        public ActionResult Index()
        {
            if (Session["AdminLoggetInn"] == null || (bool)Session["AdminLoggetInn"] == false)
            {
                return RedirectToAction("Hjem", "Nettbutikk", new { area = "" });
            }
            else
            {
                var liste = _kundeBLL.getKunder();
                return View(liste);
            }
        }

        public ActionResult KundeListe()
        {
            var tempListe = _kundeBLL.getKunder();
            var liste = new List<Kunde>();
            if (tempListe != null)
            {
                foreach (var kunde in tempListe)
                {
                    liste.Add(new Kunde
                    {
                        id = kunde.id,
                        fornavn = kunde.fornavn,
                        etternavn = kunde.etternavn,
                        adresse = kunde.adresse,
                        postnr = kunde.postnr,
                        poststed = kunde.poststed,
                        epost = kunde.epost,
                        passordId = kunde.passordId
                    });
                }
            }
            return PartialView(liste);
        }
    }
}