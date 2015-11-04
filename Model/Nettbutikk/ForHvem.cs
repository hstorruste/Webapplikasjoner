using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Model.Nettbutikk
{
    public class ForHvem
    {
        [ScaffoldColumn(false)]
        public int forId { get; set; }
        [Display(Name = "For hvem")]
        [Required(ErrorMessage = "Kan ikke være blank.")]
        public string navn { get; set; }
        [Display(Name = "Antall sko")]
        public int antallSko { get; set; }
    }
}