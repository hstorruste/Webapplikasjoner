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
        [HttpPost]
        public ActionResult Registrer(RegistrerKundeModell innKunde)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            using (var db = new NettbutikkContext())
            {
                try
                {
                    var nyKunde = new Kunder();
                    nyKunde.Fornavn = innKunde.fornavn;
                    nyKunde.Etternavn = innKunde.etternavn;
                    nyKunde.Adresse = innKunde.adresse;
                    nyKunde.Postnr = innKunde.postnr;
                    nyKunde.Poststeder.Poststed = innKunde.poststed;
                    nyKunde.Epost = innKunde.epost;
                    byte[] passordDb = DbKunder.lagHash(innKunde.passord);
                    nyKunde.Passord = passordDb;
                    db.Kunder.Add(nyKunde);
                    db.SaveChanges();
                    
                    //Tror man ska ändra session här om man ska bli inloggad när man har registrert en kunde.

                    return RedirectToAction("Hjem");
                }
                catch (Exception feil)
                {
                    return View();
                }
            }
        }

        public ActionResult RedigerKunde(int id)
        {
            RedigerKundeModell enKunde = DbKunder.hentEnKunde(id);

            return View(enKunde);
             
        }

        public ActionResult LoggInn()
        {
            return View();
        }

        public ActionResult InnLogetSide()
        {
            if (Session["LoggetInn"] != null)
            {
                bool loggetInn = (bool)Session["LoggetInn"];
                if (loggetInn)
                {
                    return View();
                }
            }
            return RedirectToAction("LoggInn");
        }
    }
}