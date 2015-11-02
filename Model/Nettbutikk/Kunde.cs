using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Nettbutikk.Model
{
    public class Kunde
    {
        public int id { get; set; }
        [Display(Name = "Navn")]
        public string fornavn { get; set; }
        public string etternavn { get; set; }
        [Display(Name = "Adresse")]
        public string adresse { get; set; }
        [Display(Name = "Postnr")]
        public string postnr { get; set; }
        [Display(Name = "Poststed")]
        public string poststed { get; set; }
        [Display(Name = "Epost")]
        public string epost { get; set; }
        [Display(Name = "Passord-Id")]
        public int passordId { get; set; }
    }
}
