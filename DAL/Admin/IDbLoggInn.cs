using Model.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Admin
{
    public interface IDbLoggInn
    {
        byte[] lagHash(string innPassord);
        bool adminIDb(LoggInn innAdmin);

    }
}
