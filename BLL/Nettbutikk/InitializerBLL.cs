using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Nettbutikk;

namespace BLL.Nettbutikk
{
    public class InitializerBLL
    {
        private DbInitializer _init;
        public void Initialize()
        {
            _init = new DbInitializer();
            _init.Initialize();
        }
    }
}
