using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nettbutikk.Models;

namespace Nettbutikk.Controllers
{
    public class SkoController : Controller
    {
        public List<Skoen> hentAlleSko()
        {
            using (var db = new NettbutikkContext())
            {
                List<Skoen> alleSko = db.Sko.Select( s => new Skoen()
                {
                    navn = s.Navn,
                    kategori = s.Kategori.Navn,
                    forHvem = s.ForHvem.Navn,
                    pris = s.Pris,
                    farge = s.Farge,
                    beskrivelse = s.Beskrivelse

                }).ToList();

                return alleSko;
            }
        }
        public ActionResult Liste()
        {
            return View(hentAlleSko());
        }
        public ActionResult Registrer()
        {
            return View();
        }
    }
}