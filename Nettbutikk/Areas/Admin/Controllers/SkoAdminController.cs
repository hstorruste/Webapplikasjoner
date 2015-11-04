using Nettbutikk.Areas.Admin.Models;
using Model.Nettbutikk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Admin;

namespace Nettbutikk.Areas.Admin.Controllers
{
    public class SkoAdminController : Controller
    {
        ISkoLogikk _skoBLL;

        public SkoAdminController()
        {
            _skoBLL = new SkoBLL();
        }

        public SkoAdminController(ISkoLogikk stub)
        {
            _skoBLL = stub;
        }

        public ActionResult Index()
        {
            return View();

        }
        public ActionResult SkoListe()
        {
            var tempListe = _skoBLL.getAktuelleSko();
            var liste = new List<SkoListeElement>();
            foreach(var sko in tempListe)
            {
                liste.Add(new SkoListeElement {
                    skoId = sko.skoId,
                    navn = sko.navn,
                    merke = sko.merke,
                    kategori = sko.kategori,
                    forHvem = sko.forHvem
                });
            }
            return PartialView(liste);
        }

        public ActionResult SlettedeSkoListe()
        {
            var tempListe = _skoBLL.getSlettedeSko();
            var liste = new List<SkoListeElement>();
            foreach (var sko in tempListe)
            {
                liste.Add(new SkoListeElement
                {
                    skoId = sko.skoId,
                    navn = sko.navn,
                    merke = sko.merke,
                    kategori = sko.kategori,
                    forHvem = sko.forHvem
                });
            }
            return PartialView(liste);
        }
    }
}