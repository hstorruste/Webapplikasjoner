using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Nettbutikk.Models;

namespace Nettbutikk.Controllers
{
    public class DbHandlevogn
    {
        public static Handlevogn getHandlevogn(HttpSessionStateBase session)
        {
            var vogn = new Handlevogn();
            vogn.varer = getAlleKundevognvarer(session);
            foreach(var vare in vogn.varer)
            {
                vogn.totalbelop += vare.pris;
            }
            
            return vogn;
        }

        public static List<HandlevognVare> getAlleKundevognvarer(HttpSessionStateBase session)
        {
            var id = session.SessionID;
            using (var db = new NettbutikkContext())
            {
                try
                {
                    
                    List<HandlevognVare> alleVarer = db.Kundevogner.Include("Sko").Include("Merke")
                        .Where(k => k.SessionId == id).Select(k => new HandlevognVare{
                            vognId = k.KundevognId,
                            skoId = k.SkoId,
                            storlek = k.Storlek,
                            skoNavn = k.Sko.Navn,
                            merke = k.Sko.Merke.Navn,
                            farge = k.Sko.Farge,
                            pris = k.Sko.Pris,
                            bildeUrl = k.Sko.Bilder.Where( b => b.BildeUrl.Contains("/Medium/")).FirstOrDefault().BildeUrl
                    }).ToList();

                    return alleVarer;
                }
                catch (Exception feil)
                {
                    return null;
                }
            }
            
        }

        public static bool leggTilVare(Kundevogner vare)
        {
            using(var db = new NettbutikkContext())
            {
                try
                {
                    db.Kundevogner.Add(vare);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception feil)
                {
                    return false;
                }
            }
        }

    }
}