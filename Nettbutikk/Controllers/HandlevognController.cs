using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nettbutikk.Models;

namespace Nettbutikk.Controllers
{
    public class HandlevognController : Controller
    {
        // GET: Handlevogn
        public ActionResult Index()
        {
            var handlevogn = DbHandlevogn.getHandlevogn(Session);
            return View(handlevogn);
        }

        public bool LeggTil(int skoId, int skoStr)
        {
            Kundevogner nyVare = new Kundevogner()
            {
                KundeId = Session.SessionID,
                Dato = DateTime.Now,
                SkoId = skoId,
                Storlek = skoStr
            };
            return DbHandlevogn.leggTilVare(nyVare);
        }
    }
}