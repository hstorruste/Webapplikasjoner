using BLL.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nettbutikk.Areas.Admin.Controllers
{
    public class KundeController : Controller
    {
        IKundeLogikk _kundeBLL;

        public KundeController()
        {
            _kundeBLL = new KundeBLL();
        }

        public KundeController(IKundeLogikk stub)
        {
            _kundeBLL = stub;
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}