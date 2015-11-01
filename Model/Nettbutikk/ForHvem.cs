using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Nettbutikk.Model
{
    public class ForHvem
    {
        [ScaffoldColumn(false)]
        public int forId { get; set; }
        [Display(Name = "For hvem")]
        public string navn { get; set; }
    }
}