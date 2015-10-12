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
                vogn.totalbelop += vare.Sko.Pris;
            }
            
            return vogn;
        }

        public static List<Kundevogner> getAlleKundevognvarer(HttpSessionStateBase session)
        {
            var id = session.SessionID;
            using (var db = new NettbutikkContext())
            {
                try
                {
                    List<Kundevogner> alleVarer = db.Kundevogner.Include("Sko").Where(k => k.KundeId == id).ToList();
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