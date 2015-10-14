using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Nettbutikk.Models
{
    public class Ordre
    {
        [ScaffoldColumn(false)]
        public int ordreId { get; set; }
        [ScaffoldColumn(false)]
        public int kundeId { get; set; }
        [Display(Name ="Dato")]
        public System.DateTime ordreDato { get; set; }
        [Display(Name = "Varer")]
        public List<HandlevognVare> varer { get; set; }
        [Display(Name = "Totalt")]
        public decimal totalBelop { get; set; }
        [Display(Name = "Navn")]
        public string kundeNavn { get; set; }
        [Display(Name = "Adresse")]
        public string adresse { get; set; }
        [Display(Name = "Postnr")]
        public string postnr { get; set; }
        [Display(Name = "Poststed")]
        public string poststed { get; set; }
    }
}