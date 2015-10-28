using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class InitializerBLL
    {
        public static void Initialize()
        {
            new Nettbutikk.DAL.Eksempeldata();
        }
    }
}
