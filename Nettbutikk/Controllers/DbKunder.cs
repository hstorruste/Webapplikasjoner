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
                return db.Kunder.FirstOrDefault(k => k.Epost == epost);
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
                catch
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
                        PassordId = enDbKundePassord.PassordId
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
                    var upPassord = db.Passorden.Where(p => p.PassordId == innPassord.PassordId).SingleOrDefault();

                    if (upPassord != null)
                    {
                        byte[] passordDb = lagHash(innPassord.nyttPassord);
                        upPassord.Passord = passordDb;
                        
                        db.SaveChanges();

                        sparadPassord = true;
                    }
                }
                catch
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
    }
}