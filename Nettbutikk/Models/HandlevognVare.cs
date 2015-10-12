using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Nettbutikk.Models
{
    public class HandlevognVare
    {
        [ScaffoldColumn(false)]
        public int vognId { get; set; }
        [ScaffoldColumn(false)]
        public int skoId { get; set; }
        [Display(Name = "Størrelse")]
        public int storlek { get; set; }
        [Display(Name ="Navn")]
        public string skoNavn { get; set; }
        [Display(Name = "Merke")]
        public string merke { get; set; }
        [Display(Name = "Farge")]
        public string farge { get; set; }
        [Display(Name = "Pris")]
        public decimal pris { get; set; }
        [Display(Name ="Bilde")]
        public string bildeUrl { get; set; }

    }
}