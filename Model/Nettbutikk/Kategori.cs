using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Model.Nettbutikk
{
    public class Kategori
    {
        [ScaffoldColumn(false)]
        public int kategoriId { get; set; }
        [Display(Name = "Kategori")]
        [Required(ErrorMessage = "Navn på kategori må oppgis")]
        public string navn { get; set; }
        [Display(Name = "Antall sko")]
        public int antallSko { get; set; }
    }
}