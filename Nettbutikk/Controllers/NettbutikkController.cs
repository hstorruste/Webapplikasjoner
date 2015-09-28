using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nettbutikk.Controllers
{
    public class NettbutikkController : Controller
    {
        // GET: Nettbutikk
        public ActionResult Index()
        {
            return View();
        }
    }
}