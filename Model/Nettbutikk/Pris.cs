using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Nettbutikk
{
    public class Pris
    {
        [ScaffoldColumn(false)]
        public int skoId { get; set; }
        [ScaffoldColumn(false)]
        [Display(Name = "Navn")]
        public string skoNavn { get; set; }
        [Display(Name = "Fra dato")]
        public DateTime dato { get; set; }
        [Display(Name = "Pris")]
        [Required(ErrorMessage = "Skoen må ha en pris")]
        public decimal pris { get; set; }
    }
}
