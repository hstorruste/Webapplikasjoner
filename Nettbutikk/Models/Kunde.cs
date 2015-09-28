using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Nettbutikk.Models
{
    public class Kunde
    {
        public int id { get; set; }
        [Display(Name = "Fornavn")]
        [Required(ErrorMessage = "Fornavn må oppgis")]
        public string fornavn { get; set; }
        [Display(Name = "Etternavn")]
        [Required(ErrorMessage = "Etternavn må oppgis")]
        public string etternavn { get; set; }
        [Display(Name = "Adresse")]
        [Required(ErrorMessage = "Adresse må oppgis")]
        public string adresse { get; set; }
        [Display(Name = "Postnr")]
        [Required(ErrorMessage = "Postnr må oppgis")]
        [RegularExpression(@"[0-9]{4}", ErrorMessage = "Postnr må väre 4 siffer")]
        public string postnr { get; set; }
        [Display(Name = "Poststed")]
        [Required(ErrorMessage = "Poststed må oppgis")]
        public string poststed { get; set; }
        [Display(Name = "Epost")]
        [Required(ErrorMessage = "Epost må oppgis")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$", ErrorMessage = "Oppgi en gyldig epost")]
        public string epost { get; set; }
        [DataType(DataType.Password)]
        [StringLength(255,MinimumLength = 8, ErrorMessage = "Passord må være mellom 8 og 255 tegn")]
        [Display(Name = "Passord")]
        [Required(ErrorMessage = "Passord må oppgis")]
        [MembershipPassword()]
        public string passord { get; set; }
        [Compare("passord",ErrorMessage = "Passordet er ikke likt")]
        [DataType(DataType.Password)]
        [StringLength(255, MinimumLength = 8, ErrorMessage = "Passord må være mellom 8 og 255 tegn")]
        [Display(Name = "Bekreft Passord")]
        [Required(ErrorMessage = "Passord må oppgis")]
        [MembershipPassword()]
        public string bekreftPassord { get; set; }
    }
}
