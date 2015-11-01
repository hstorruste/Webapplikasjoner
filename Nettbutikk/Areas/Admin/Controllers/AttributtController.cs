using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Admin.BLL;
using Nettbutikk.Model;

namespace Nettbutikk.Areas.Admin.Controllers
{
    public class AttributtController : Controller
    {
        IAttributtLogikk _attributtBLL;

        public AttributtController()
        {
            _attributtBLL = new AttributtBLL();
        }

        public AttributtController(IAttributtLogikk stub)
        {
            _attributtBLL = stub;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListeFor()
        {
            var liste = _attributtBLL.getFor();
            return PartialView(liste);
        }

        public ActionResult ListeKategorier()
        {
            var liste = _attributtBLL.getKategorier();
            return PartialView(liste);
        }

        public ActionResult ListeMerker()
        {
            var liste = _attributtBLL.getMerke();
            return PartialView(liste);
        }

        [HttpPost]
        public JsonResult LeggTilFor(ForHvem ny)
        {
            var lagtTil = _attributtBLL.addFor(ny.navn);
            return Json(lagtTil);
        }

        [HttpPost]
        public JsonResult LeggTilKategori(Kategori ny)
        {
            var lagtTil = _attributtBLL.addKategori(ny.navn);
            return Json(lagtTil);
        }

        [HttpPost]
        public JsonResult LeggTilMerke(Merke ny)
        {
            var lagtTil = _attributtBLL.addMerke(ny.navn);
            return Json(lagtTil);
        }

        [HttpPost]
        public JsonResult OppdaterMerke(Merke item)
        {
            var redigert = _attributtBLL.updateMerke(item);
            return Json(redigert);
        }
    }
}