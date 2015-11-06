using Model.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Admin
{
    public interface ILoggInnLogikk
    {
        byte[] lagHash(string innPassord);
        bool adminIDb(LoggInn innAdmin);
    }
}
