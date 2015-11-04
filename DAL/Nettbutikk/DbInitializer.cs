using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Nettbutikk
{
    public class DbInitializer
    {
        public void Initialize()
        {
            System.Data.Entity.Database.SetInitializer(new Eksempeldata());
        }
    }
}
