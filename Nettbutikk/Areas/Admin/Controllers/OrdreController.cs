using BLL.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nettbutikk.Areas.Admin.Controllers
{
    public class OrdreController : Controller
    {
        IOrdreLogikk _ordreBLL;

        public OrdreController()
        {
            _ordreBLL = new OrdreBLL();
        }

        public OrdreController(IOrdreLogikk stub)
        {
            _ordreBLL = stub;
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
        public ActionResult OrdreListe()
        {
            var liste = _ordreBLL.getOrdrer();
            return PartialView(liste);
        }
    }
}