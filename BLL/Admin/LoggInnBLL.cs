using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Admin;
using DAL.Admin;

namespace BLL.Admin
{
    public class LoggInnBLL : ILoggInnLogikk
    {
        private IDbLoggInn _repo;

        public LoggInnBLL()
        {
            _repo = new DbLoggInn();
        }

        public LoggInnBLL(DbLoggInnStub stub)
        {
            _repo = stub;
        }
        public bool adminIDb(LoggInn innAdmin)
        {
            return _repo.adminIDb(innAdmin);
        }

        public byte[] lagHash(string innPassord)
        {
            throw new NotImplementedException();
        }
    }
}
