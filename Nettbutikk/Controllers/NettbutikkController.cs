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
            return View(DbSko.hentAlleSko());
        }

    }
}