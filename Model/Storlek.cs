using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nettbutikk.Model
{
    public class Storlek
    {
        [Display(Name = "StørrelseId")]
        public int storlekId { get; set; }
        [Display(Name = "Størrelse")]
        public int storlek { get; set; }
        [Display(Name = "Antall")]
        public int antall { get; set; }
    }
}
