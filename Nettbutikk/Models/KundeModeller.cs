using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Nettbutikk.Models
{
    public class RegistrerKundeModell
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
        [RegularExpression(@"[0-9]{4}", ErrorMessage = "Postnr må være 4 siffer")]
        public string postnr { get; set; }
        [Display(Name = "Poststed")]
        [Required(ErrorMessage = "Poststed må oppgis")]
        public string poststed { get; set; }
        [Display(Name = "Epost")]
        [Required(ErrorMessage = "Epost må oppgis")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Oppgi en gyldig epost")]
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

    public class RedigerKundeModell {
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
        [RegularExpression(@"[0-9]{4}", ErrorMessage = "Postnr må være 4 siffer")]
        public string postnr { get; set; }
        [Display(Name = "Poststed")]
        [Required(ErrorMessage = "Poststed må oppgis")]
        public string poststed { get; set; }
        [Display(Name = "Epost")]
        [Required(ErrorMessage = "Epost må oppgis")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Oppgi en gyldig epost")]
        public string epost { get; set; }
    }

    public class bytteKundePassord
    {
        [DataType(DataType.Password)]
        [StringLength(255, MinimumLength = 8, ErrorMessage = "Passord må være mellom 8 og 255 tegn")]
        [Display(Name = "Gammelt passord")]
        [Required(ErrorMessage = "Passord må oppgis")]
        public string gammeltPassord { get; set; }
        [DataType(DataType.Password)]
        [StringLength(255, MinimumLength = 8, ErrorMessage = "Passord må være mellom 8 og 255 tegn")]
        [Display(Name = "Nytt passord")]
        [Required(ErrorMessage = "Passord må oppgis")]
        [MembershipPassword()]
        public string nyttPassord { get; set; }
        [Compare("passord", ErrorMessage = "Passordet er ikke likt")]
        [DataType(DataType.Password)]
        [StringLength(255, MinimumLength = 8, ErrorMessage = "Passord må være mellom 8 og 255 tegn")]
        [Display(Name = "Bekreft Passord")]
        [Required(ErrorMessage = "Passord må oppgis")]
        [MembershipPassword()]
        public string bekreftPassord { get; set; }
    }

    public class LoggInnModell
    {
        [Required]
        [Display(Name = "Epost")]
        public string Epost { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Passord")]
        public string passord { get; set; }

        /* Funderar på om jag ska ta bort denna. Har inte användt den än.
        [Display(Name = "Husk meg?")]
        public bool huskMeg { get; set; }*/
    }
}
