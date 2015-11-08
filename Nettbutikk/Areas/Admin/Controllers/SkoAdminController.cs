using Nettbutikk.Areas.Admin.Models;
using Model.Nettbutikk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Admin;
using System.IO;
using System.Threading.Tasks;

namespace Nettbutikk.Areas.Admin.Controllers
{
    public class SkoAdminController : Controller
    {
        ISkoLogikk _skoBLL;
        IAttributtLogikk _attributtBLL;

        public SkoAdminController()
        {
            _skoBLL = new SkoBLL();
            _attributtBLL = new AttributtBLL();
        }

        public SkoAdminController(ISkoLogikk skoStub, IAttributtLogikk attributtStub)
        {
            _skoBLL = skoStub;
            _attributtBLL = attributtStub;
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
        public ActionResult SkoListe()
        {
            var tempListe = _skoBLL.getAktuelleSko();
            var liste = new List<SkoListeElement>();
            if (tempListe != null)
            {
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
            }
            return PartialView(liste);
        }

        [ChildActionOnly]
        public ActionResult SlettedeSkoListe()
        {
            var tempListe = _skoBLL.getSlettedeSko();
            var liste = new List<SkoListeElement>();
            if (tempListe != null)
            {
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
            }
            return PartialView(liste);
        }

        public ActionResult Detaljer(int id)
        {
            if (Session["AdminLoggetInn"] == null || (bool)Session["AdminLoggetInn"] == false)
            {
                return RedirectToAction("Hjem", "Nettbutikk", new { area = "" });
            }
            else
            {
                var enSko = _skoBLL.getSko(id);
                return View(enSko);
            }
        }

        [HttpGet]
        public ActionResult Prishistorikk(int skoId)
        {
            var priser = _skoBLL.getPrishistorikk(skoId);
            return PartialView(priser);
        }

        [HttpPost]
        public bool Slett(int skoId)
        {
            var slettet = _skoBLL.slett(skoId);
            if(slettet == null)
            {
                ViewBag.Feil = "Sko med id: " + skoId + " ble ikke slettet!";
                return false;
            }
            return true;
        }

        public ActionResult SlettModal(Skoen enSko)
        {
            return PartialView(enSko);
        }

        public bool Gjenopprett(int skoId)
        {
            var gjenopprettet = _skoBLL.gjenopprett(skoId);
            if (gjenopprettet == null)
            {
                ViewBag.Feil = "Sko med id: " + skoId + " ble ikke slettet!";
                return false;
            }
            return true;
        }

        public ActionResult NySko()
        {
            if (Session["AdminLoggetInn"] == null || (bool)Session["AdminLoggetInn"] == false)
            {
                return RedirectToAction("Hjem", "Nettbutikk", new { area = "" });
            }
            else
            {
                ViewData["merkeListe"] = _attributtBLL.getMerke();
                ViewData["kategoriListe"] = _attributtBLL.getKategorier();
                ViewData["forListe"] = _attributtBLL.getFor();
                return View();
            }
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult NySko(Skoen innSko)
        {
            if (ModelState.IsValid)
            {
                var lagretSko = _skoBLL.lagreSko(innSko);
                if (lagretSko != null)
                {
                    return RedirectToAction("NySkoDel2", "SkoAdmin", lagretSko );
                }
                else
                {
                    ViewData["lagreError"] = "Noe gikk galt! Skoen ble ikke lagret i databasen.";
                }
            }
            ViewData["merkeListe"] = _attributtBLL.getMerke();
            ViewData["kategoriListe"] = _attributtBLL.getKategorier();
            ViewData["forListe"] = _attributtBLL.getFor();
            return View();
        }

        public ActionResult NySkoDel2(Skoen innsko)
        {
            return View(innsko);
        }

        [HttpPost]
        public JsonResult LeggTilStr(int skoId, Storlek ny)
        {
            var lagtTil = _skoBLL.leggTilStorlek(skoId, ny);
            return Json(lagtTil);
        }

        [HttpPost]
        public JsonResult LeggTilBilde(int skoId, Bilde ny)
        {
            var lagtTil = _skoBLL.leggTilBilde(skoId, ny);
            return Json(lagtTil);
        }

        [HttpPost]
        public async Task<JsonResult> LastOppBilde(string bildeStr)
        {
            try { 
                foreach (string fil in Request.Files)
                {
                    var filInnhold = Request.Files[fil];
                    if (filInnhold != null && filInnhold.ContentLength > 0)
                    {
                        var stream = filInnhold.InputStream;
                        var filnavn = Path.GetFileName(fil);
                        var path = Path.Combine(Server.MapPath("~/Pictures/Sko"), bildeStr, filnavn);
                        using (var filStream = System.IO.File.Create(path))
                        {
                            stream.CopyTo(filStream);
                        }
                    }
                }
            }
            catch
            {
                return Json("Opplasting feilet!");
            }
            return Json("Fil ble opplastet!");
        }

        [HttpPost]
        public JsonResult SlettStr(int id)
        {
            var slettet = _skoBLL.slettStorlek(id);
            return Json(slettet);
        }

        [HttpPost]
        public JsonResult SlettBilde(int id)
        {
            var slettet = _skoBLL.slettBilde(id);
            return Json(slettet);
        }
    }
}