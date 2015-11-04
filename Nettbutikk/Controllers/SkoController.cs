using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Nettbutikk;
using BLL.Nettbutikk;

namespace Nettbutikk.Controllers
{
    public class SkoController : Controller
    {
        ISkoLogikk _skoBLL;

        public SkoController()
        {
            _skoBLL = new SkoBLL();
        }
        public ActionResult Liste()
        {
            return View(_skoBLL.hentAlleSko());
        }
        public ActionResult Registrer()
        {
            return View();
        }

        public ActionResult Detaljer(int skoId)
        {
            var ensko = _skoBLL.hentEnSko(skoId);
            return View(ensko);
        }

        [ChildActionOnly]
        public ActionResult vareNav()
        {
            List<ForHvem> forHvem = _skoBLL.hentAlleForHvem();
            return PartialView(forHvem);
        }

        [ChildActionOnly]
        public ActionResult vareNavKategorier(int forHvem)
        {
            ViewData["ForHvemId"] = forHvem;
            List<Kategori> kategorier = _skoBLL.hentAlleKategorierForHvem(forHvem);
            return PartialView(kategorier);
        }
    }
}