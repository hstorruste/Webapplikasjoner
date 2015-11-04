using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Nettbutikk;
using BLL.Nettbutikk;

namespace Nettbutikk.Controllers
{
    public class NettbutikkController : Controller
    {
        ISkoLogikk _skoBLL;

        public NettbutikkController()
        {
            _skoBLL = new SkoBLL();
        }
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

            var skoene = _skoBLL.hentAlleSko();
            return View(skoene);
        }

        public ActionResult ForHvem(int forHvemId)
        {
            List<Kategori> kategorier = _skoBLL.hentAlleKategorierForHvem(forHvemId);
            ViewData["ForHvemId"] = forHvemId;
            ViewData["ForHvem"] = _skoBLL.getFor(forHvemId).navn;
            return View(kategorier);
        }

        public ActionResult Kategori(int forHvemId, int kategoriId)
        {
            ViewData["ForHvemId"] = forHvemId;
            ViewData["ForHvem"] = _skoBLL.getFor(forHvemId).navn;
            Kategori kategori = _skoBLL.getKategori(kategoriId);
            return View(kategori);
        }

        public ActionResult KategoriPartial(int forHvemId, int kategoriId)
        {
            List<Skoen> skoene = _skoBLL.hentAlleSkoFor(forHvemId, kategoriId);
            return PartialView(skoene);
        }

        public ActionResult ListePartial(Skoen sko)
        {
            return PartialView(sko);
        }

    }
}