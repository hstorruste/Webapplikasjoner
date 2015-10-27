using Nettbutikk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nettbutikk.Controllers
{
    public class DbKunder
    {
        public static Kunder getKunde(string epost)
        {
            using (var db = new NettbutikkContext())
            {
                return db.Kunder.Include("Passorden").FirstOrDefault(k => k.Epost == epost);
            }
        }

        public static Passorden getKundePassord(int innPassordId)
        {
            using (var db = new NettbutikkContext())
            {
                return db.Passorden.FirstOrDefault(p => p.PassordId == innPassordId);
            }
        }

        public static bool registrerKunde(RegistrerKundeModell innKunde)
        {
            using (var db = new NettbutikkContext())
            {
                try
                {
                    //Test för att göra Email unikt. Vet inte om detta är det bästa sättet.
                    var finnesKunde = db.Kunder.FirstOrDefault(k => k.Epost == innKunde.epost);
                    if (finnesKunde == null)
                    {
                        var nyKunde = new Kunder();
                        nyKunde.Fornavn = innKunde.fornavn;
                        nyKunde.Etternavn = innKunde.etternavn;
                        nyKunde.Adresse = innKunde.adresse;
                        nyKunde.Postnr = innKunde.postnr;
                        var eksisterandePostnr = db.Poststeder.Find(innKunde.postnr);
                        if (eksisterandePostnr == null)
                        {
                            var nyttPoststed = new Poststeder()
                            {
                                Postnr = innKunde.postnr,
                                Poststed = innKunde.poststed
                            };
                            nyKunde.Poststeder = nyttPoststed;
                        }
                        nyKunde.Epost = innKunde.epost;
                        byte[] passordDb = lagHash(innKunde.passord);
                        var passord = new Passorden()
                        {
                            Passord = passordDb,
                            Kunde = nyKunde,
                        };
                        nyKunde.Passorden = passord;
                        db.Kunder.Add(nyKunde);
                        db.SaveChanges();

                        return true;
                    }
                    else
                    {  
                        return false;
                    }
                }
                catch (Exception feil)
                {
                    return false;
                }
            }
        }

        public static RedigerKundeModell hentEnKunde(int id)
        {
            using (var db = new NettbutikkContext())
            {
                var enDbKunde = db.Kunder.Find(id);

                if (enDbKunde == null)
                    return null;
                else
                {
                    var utKunde = new RedigerKundeModell()
                    {
                        id = enDbKunde.Id,
                        fornavn = enDbKunde.Fornavn,
                        etternavn = enDbKunde.Etternavn,
                        adresse = enDbKunde.Adresse,
                        postnr = enDbKunde.Postnr,
                        poststed = enDbKunde.Poststeder.Poststed,
                        epost = enDbKunde.Epost
                    };
                    return utKunde;
                }
            }
        }

        public static bool redigerKunde(RedigerKundeModell innKunde)
        {
            bool sparadKunde = false;

            using (var db = new NettbutikkContext())
            {
                try
                {
                    var upKunde = db.Kunder.Where(k => k.Id == innKunde.id).SingleOrDefault();
                    var finnesKunde = db.Kunder.FirstOrDefault(k => k.Epost == innKunde.epost);

                    if (finnesKunde.Id == innKunde.id)
                    {
                        finnesKunde = null;
                    }

                    if (finnesKunde == null && upKunde != null)
                    {
                        upKunde.Fornavn = innKunde.fornavn;
                        upKunde.Etternavn = innKunde.etternavn;
                        upKunde.Adresse = innKunde.adresse;
                        upKunde.Postnr = innKunde.postnr;
                        var eksisterandePostnr = db.Poststeder.Find(innKunde.postnr);
                        if (eksisterandePostnr == null)
                        {
                            var nyttPoststed = new Poststeder()
                            {
                                Postnr = innKunde.postnr,
                                Poststed = innKunde.poststed
                            };
                            upKunde.Poststeder = nyttPoststed;
                        }
                        upKunde.Epost = innKunde.epost;
                        db.SaveChanges();

                        sparadKunde = true;
                    }
                }
                catch (Exception feil)
                {
                    sparadKunde = false;
                }
                return sparadKunde;
            }
        }

        public static RedigerKundePassordModell hentEnKundePassord(int passordId)
        {
            using (var db = new NettbutikkContext())
            {
                var enDbKundePassord = db.Passorden.Find(passordId);

                if (enDbKundePassord == null)
                    return null;
                else
                {
                    var utKundePassord = new RedigerKundePassordModell()
                    {
                        passordId = enDbKundePassord.PassordId
                    };
                    return utKundePassord;
                }
            }
        }
        public static bool redigerKundePassord(RedigerKundePassordModell innPassord)
        {
            bool sparadPassord = false;

            using (var db = new NettbutikkContext())
            {
                try
                {
                    var upPassord = db.Passorden.Where(p => p.PassordId == innPassord.passordId).SingleOrDefault();

                    if (upPassord != null)
                    {
                        byte[] gammeltpassordDb = lagHash(innPassord.gammeltPassord);
                        byte[] passordDb = lagHash(innPassord.nyttPassord);
                        //Sjekker om det er skrevet riktig gammelt passord.
                        if (!gammeltpassordDb.SequenceEqual(upPassord.Passord))
                        {
                            return false;
                        }

                        upPassord.Passord = passordDb;
                        
                        db.SaveChanges();

                        sparadPassord = true;
                    }
                }
                catch(Exception feil)
                {
                    sparadPassord = false;
                }
                return sparadPassord;
            }
        }

        public static byte[] lagHash(string innPassord)
        {
            byte[] innData, utData;
            var algoritme = System.Security.Cryptography.SHA256.Create();
            innData = System.Text.Encoding.ASCII.GetBytes(innPassord);
            utData = algoritme.ComputeHash(innData);
            return utData;
        }

        public static bool Kunde_i_DB(LoggInnModell innKunde)
        {
            using (var db = new NettbutikkContext())
            {
                byte[] passordDb = lagHash(innKunde.passord);
                Kunder funnetKunde = db.Kunder.FirstOrDefault
                    (k => k.Passorden.Passord == passordDb && k.Epost == innKunde.Epost);
                if (funnetKunde == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public static Ordrer getOrdre(int ordreId)
        {
            using (var db = new NettbutikkContext())
            {
                try
                {
                    Ordrer enOrdre = db.Ordrer.Include("OrdreDetaljer.Sko.Merke").Include("OrdreDetaljer.Sko.Bilder").Include("Kunder.Poststeder")
                        .SingleOrDefault(o => o.OrdreId == ordreId);
                    return enOrdre;
                }
                catch (Exception feil)
                {
                    return null;
                }
            }
        }

        public static bool arkiverOrdre(string sessionId, int kundeId)
        {
            var nyOrdre = DbHandlevogn.lagOrdre(sessionId, kundeId);
            using (var db = new NettbutikkContext())
            {
                try
                {
                    //Må sette relasjonene i ordrer og ordredetaljer til entiteter i databasen ellers forsøkes sko og kunde å lagres på nytt i databasen.
                    foreach (var detalj in nyOrdre.OrdreDetaljer)
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
            using (var db = new NettbutikkContext())
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
    }
}