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
        public static Handlevogn getHandlevogn(string sessionId)
        {
            var vogn = new Handlevogn();
            vogn.varer = getAlleKundevognvarer(sessionId);
            foreach(var vare in vogn.varer)
            {
                vogn.totalbelop += vare.pris;
            }
            
            return vogn;
        }

        public static List<HandlevognVare> getAlleKundevognvarer(string sessionId)
        {
            using (var db = new NettbutikkContext())
            {
                try
                {
                    
                    List<HandlevognVare> alleVarer = db.Kundevogner.Include("Sko").Include("Merke")
                        .Where(k => k.SessionId == sessionId).Select(k => new HandlevognVare{
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

        public static bool fjernVare(int vareId)
        {
            using (var db = new NettbutikkContext())
            {
                try
                {
                    db.Kundevogner.Remove(db.Kundevogner.Find(vareId));
                    db.SaveChanges();
                    return true;
                }
                catch (Exception feil)
                {
                    return false;
                }
            }
        }

        public static bool fjernAlleVarer( string sessionId)
        {
            using (var db = new NettbutikkContext())
            {
                try
                {
                    db.Kundevogner.RemoveRange(db.Kundevogner.Where(k => k.SessionId == sessionId ));
                    db.SaveChanges();
                    return true;
                }
                catch (Exception feil)
                {
                    return false;
                }
            }
        }

        public static decimal getTotalpris(string sessionId)
        {
            using (var db = new NettbutikkContext())
            {
                try
                {
                    decimal total = 0;
                    foreach(var vare in db.Kundevogner.Include("Sko").Where(k => k.SessionId == sessionId))
                    {
                        total += vare.Sko.Pris;
                    }
                    return total;
                }
                catch (Exception feil)
                {
                    return 0;
                }
            }
        } 

        public static Ordrer lagOrdre(string sessionId, int kundeId)
        {
            using (var db = new NettbutikkContext())
            {
                try
                {
                    //Måtte dele opp databasekallet og laging av new OrdreDetaljer. 
                    //Det var ikke lov å opprette OrdreDetaljer i entity til Linq forespørsel.
                    List<Kundevogner> temp = db.Kundevogner.Include("Sko.Merke").Include("Sko.Bilder")
                        .Where(k => k.SessionId == sessionId).ToList();

                    List<OrdreDetaljer> enkeltVarer = temp.Select( v => new OrdreDetaljer
                    {
                        Antall = 1,
                        SkoId = v.SkoId,
                        Sko = v.Sko,
                        Pris = v.Sko.Pris,
                        Storlek = v.Storlek

                    }).ToList();

                    decimal total = 0;
                    foreach (var vare in enkeltVarer)
                        total += vare.Pris * vare.Antall;

                    Ordrer nyOrdre = new Ordrer()
                    {
                        KundeId = kundeId,
                        OrdreDato = DateTime.Now,
                        OrdreDetaljer = enkeltVarer,
                        TotalBelop = total
                    };
                    nyOrdre.Kunder = db.Kunder.Include("Poststeder").FirstOrDefault(k => k.Id == nyOrdre.KundeId);

                    return nyOrdre;
                }
                catch (Exception feil)
                {
                    return null;
                }
            }

        }

        public static bool arkiverOrdre(Ordrer nyOrdre)
        {
            using (var db = new NettbutikkContext())
            {
                try
                {
                    //Må sette relasjonene i ordrer og ordredetaljer til entiteter i databasen ellers forsøkes sko og kunde å lagres på nytt i databasen.
                    foreach(var detalj in nyOrdre.OrdreDetaljer)
                    {
                        detalj.Sko = db.Sko.Find(detalj.SkoId);
                    }
                    nyOrdre.Kunder = db.Kunder.Find(nyOrdre.KundeId);

                    db.Ordrer.Add(nyOrdre);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception feil)
                {
                    return false;
                }
            }
        }

        public static List<Ordrer> finnAlleOrdre(int KundeId)
        {
            using( var db = new NettbutikkContext())
            {
                try
                {
                    List<Ordrer> alleOrdre = db.Ordrer.Where(o => o.KundeId == KundeId).ToList();
                    return alleOrdre;
                }
                catch (Exception feil)
                {
                    return null;
                }
            }
        }

        public static Ordrer finnSisteOrdre(int KundeId)
        {
            using (var db = new NettbutikkContext())
            {
                try
                {
                    Ordrer sisteOrdre = db.Ordrer.Include("OrdreDetaljer.Sko.Merke").Include("OrdreDetaljer.Sko.Bilder").Include("Kunder.Poststeder")
                        .Where(o => o.KundeId == KundeId).OrderByDescending(o => o.OrdreDato).FirstOrDefault();
                    return sisteOrdre;
                }
                catch (Exception feil)
                {
                    return null;
                }
            }
        }

        public static bool slettAlleHandlevognVarer(string sessionId)
        {
            using (var db = new NettbutikkContext())
            {
                try
                {
                    db.Kundevogner.RemoveRange(db.Kundevogner.Where(k => k.SessionId == sessionId));
                    db.SaveChanges();
                    return true;
                }
                catch (Exception feil)
                {
                    return false;
                }
            }
        }

        public static int antallHandlevognVarer(string sessionId)
        {
            using (var db = new NettbutikkContext())
            {
                try
                {
                    int antall = 0;
                    var varer = db.Kundevogner.Where(k => k.SessionId == sessionId).ToList();
                    foreach(var vare in varer)
                    {
                        antall++;
                    }

                    return antall;
                }
                catch (Exception feil)
                {
                    return -1;
                }
            }
        }
        //TODO - lag en metode som sletter alle "gamle kundevogner"- de som har utløpt på dato.
    }
}