using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nettbutikk.Models;

namespace Nettbutikk.Controllers
{
    public class SkoController : Controller
    {
        public ActionResult Liste()
        {
            return View(DbSko.hentAlleSko());
        }
        public ActionResult Registrer()
        {
            return View();
        }

        public ActionResult Detaljer(int skoId)
        {
            var ensko = DbSko.hentEnSko(skoId);
            return View(ensko);
        }

        [ChildActionOnly]
        public ActionResult vareNav()
        {
            List<ForHvem> forHvem = DbSko.hentAlleForHvem();
            return PartialView(forHvem);
        }

        [ChildActionOnly]
        public ActionResult vareNavKategorier(int forHvem)
        {
            ViewData["ForHvemId"] = forHvem;
            List<Kategori> kategorier = DbSko.hentAlleKategorierForHvem(forHvem);
            return PartialView(kategorier);
        }
    }
}