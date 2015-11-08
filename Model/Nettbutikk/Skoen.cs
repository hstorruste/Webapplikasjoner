using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Model.Nettbutikk
{
    public class Skoen
    {
        [ScaffoldColumn(false)]
        public int skoId { get; set; }
        [Display(Name = "Navn")]
        [Required(ErrorMessage = "Navn må oppgis")]
        public string navn { get; set; }
        [Display(Name = "Merke")]
        [Required(ErrorMessage = "Det må oppgis et merke")]
        public string merke { get; set; }
        [Display(Name = "Farge")]
        public string farge { get; set; }
        [Display(Name = "Kategori")]
        [Required(ErrorMessage = "Det må oppgis en kategori")]
        public string kategori { get; set; }
        [Display(Name = "For hvem")]
        [Required(ErrorMessage = "Det må oppgis hvem skoen er for")]
        public string forHvem { get; set; }
        [Display(Name = "Størrelser")]
        public List<Storlek> storlekar { get; set; }
        [Display(Name = "Pris")]
        [Required(ErrorMessage = "Pris må oppgis")]
        public decimal pris { get; set; }
        [Display(Name = "Beskrivelse")]
        public string beskrivelse { get; set; }
        [Display(Name = "Bilder")]
        public List<Bilde> bilder { get; set; }
        [ScaffoldColumn(false)]
        public bool slettet { get; set; }
    }
}