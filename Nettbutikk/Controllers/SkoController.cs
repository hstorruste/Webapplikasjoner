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
            return View(DbSko.hentEnSko(skoId));
        }
    }
}