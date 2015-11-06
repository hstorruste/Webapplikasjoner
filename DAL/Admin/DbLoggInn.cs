using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Admin;
using DAL.Nettbutikk;

namespace DAL.Admin
{
    public class DbLoggInn : IDbLoggInn
    {
        public bool adminIDb(LoggInn innAdmin)
        {
            using (var db = new NettbutikkContext())
            {
                byte[] passordDb = lagHash(innAdmin.passord);
                Nettbutikk.Admin funnetAdmin = db.Admin.FirstOrDefault
                    (a => a.Passord == passordDb && a.Brukernavn == innAdmin.Brukernavn);
                if (funnetAdmin == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public byte[] lagHash(string innPassord)
        {
            byte[] innData, utData;
            var algoritme = System.Security.Cryptography.SHA256.Create();
            innData = System.Text.Encoding.ASCII.GetBytes(innPassord);
            utData = algoritme.ComputeHash(innData);
            return utData;
        }
    }
}
