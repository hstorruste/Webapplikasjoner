using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nettbutikk.Models;

namespace Nettbutikk.Controllers
{
    public class KundeController : Controller
    {
        public ActionResult RegistrerKunde()
        {
            return View();
        }

        public ActionResult RedigerKunde(int id)
        {
            RedigerKundeModell enKunde = DbKunder.hentEnKunde(id);

            return View(enKunde);
             
        }
    }
}