using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nettbutikk.Areas.Admin.Models
{
    public class SkoListeElement
    {
        [ScaffoldColumn(false)]
        public int skoId { get; set; }
        [Display(Name = "Navn")]
        [Required(ErrorMessage = "Navn må oppgis")]
        public string navn { get; set; }
        [Display(Name = "Merke")]
        [Required(ErrorMessage = "Det må oppgis et merke")]
        public string merke { get; set; }
        [Display(Name = "Kategori")]
        [Required(ErrorMessage = "Det må oppgis en kategori")]
        public string kategori { get; set; }
        [Display(Name = "For hvem")]
        [Required(ErrorMessage = "Det må oppgis hvem skoen er for")]
        public string forHvem { get; set; }

    }
}