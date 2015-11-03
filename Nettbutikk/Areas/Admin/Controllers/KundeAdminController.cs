using BLL.Admin;
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
            var liste = _kundeBLL.getKunder();
            return View(liste);
        }
    }
}