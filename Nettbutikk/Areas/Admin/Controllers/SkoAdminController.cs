using Nettbutikk.Areas.Admin.Models;
using Model.Nettbutikk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Admin;

namespace Nettbutikk.Areas.Admin.Controllers
{
    public class SkoAdminController : Controller
    {
        ISkoLogikk _skoBLL;

        public SkoAdminController()
        {
            _skoBLL = new SkoBLL();
        }

        public SkoAdminController(ISkoLogikk stub)
        {
            _skoBLL = stub;
        }

        public ActionResult Index()
        {
            if (Session["AdminLoggetInn"] == null || (bool)Session["AdminLoggetInn"] == false)
            {
                return RedirectToAction("Hjem", "Nettbutikk", new { area = "" });
            }
            else
            {
                return View();
            }
        }

        [ChildActionOnly]
        public ActionResult SkoListe()
        {
            var tempListe = _skoBLL.getAktuelleSko();
            var liste = new List<SkoListeElement>();
            if (tempListe != null)
            {
                foreach (var sko in tempListe)
                {
                    liste.Add(new SkoListeElement
                    {
                        skoId = sko.skoId,
                        navn = sko.navn,
                        merke = sko.merke,
                        kategori = sko.kategori,
                        forHvem = sko.forHvem
                    });
                }
            }
            return PartialView(liste);
        }

        [ChildActionOnly]
        public ActionResult SlettedeSkoListe()
        {
            var tempListe = _skoBLL.getSlettedeSko();
            var liste = new List<SkoListeElement>();
            if (tempListe != null)
            {
                foreach (var sko in tempListe)
                {
                    liste.Add(new SkoListeElement
                    {
                        skoId = sko.skoId,
                        navn = sko.navn,
                        merke = sko.merke,
                        kategori = sko.kategori,
                        forHvem = sko.forHvem
                    });
                }
            }
            return PartialView(liste);
        }

        public ActionResult Detaljer(int id)
        {
            if (Session["AdminLoggetInn"] == null || (bool)Session["AdminLoggetInn"] == false)
            {
                return RedirectToAction("Hjem", "Nettbutikk", new { area = "" });
            }
            else
            {
                var enSko = _skoBLL.getSko(id);
                return View(enSko);
            }
        }

        [HttpGet]
        public ActionResult Prishistorikk(int skoId)
        {
            var priser = _skoBLL.getPrishistorikk(skoId);
            return PartialView(priser);
        }

        [HttpPost]
        public ActionResult Slett(int skoId)
        {
            var slettet = _skoBLL.slett(skoId);
            if(slettet == null)
            {
                ViewBag.Feil = "Sko med id: " + skoId + " ble ikke slettet!";
            }
            return RedirectToAction("Index");
        }
    }
}