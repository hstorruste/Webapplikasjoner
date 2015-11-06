using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Admin;

namespace DAL.Admin
{
    public class DbLoggInnStub : IDbLoggInn
    {
        public bool adminIDb(LoggInn innAdmin)
        {
            throw new NotImplementedException();
        }

        public byte[] lagHash(string innPassord)
        {
            throw new NotImplementedException();
        }
    }
}
