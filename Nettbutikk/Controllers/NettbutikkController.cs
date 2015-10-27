using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nettbutikk.Models;

namespace Nettbutikk.Controllers
{
    public class NettbutikkController : Controller
    {
        public ActionResult Hjem()
        {
            if (Session["LoggetInn"] == null)
            {
                Session["LoggetInn"] = false;
                ViewBag.Innlogget = false;
            }
            else
            {
                ViewBag.Innlogget = (bool)Session["LoggetInn"];
            }

            var skoene = DbSko.hentAlleSko();
            return View(skoene);
        }

        public ActionResult ForHvem(int forHvemId)
        {
            List<Kategori> kategorier = DbSko.hentAlleKategorierForHvem(forHvemId);
            ViewData["ForHvemId"] = forHvemId;
            ViewData["ForHvem"] = DbSko.getFor(forHvemId).navn;
            return View(kategorier);
        }

        public ActionResult Kategori(int forHvemId, int kategoriId)
        {
            ViewData["ForHvemId"] = forHvemId;
            ViewData["ForHvem"] = DbSko.getFor(forHvemId).navn;
            Kategori kategori = DbSko.getKategori(kategoriId);
            return View(kategori);
        }

        public ActionResult KategoriPartial(int forHvemId, int kategoriId)
        {
            List<Skoen> skoene = DbSko.hentAlleSkoFor(forHvemId, kategoriId);
            return PartialView(skoene);
        }

        public ActionResult ListePartial(Skoen sko)
        {
            return PartialView(sko);
        }

    }
}