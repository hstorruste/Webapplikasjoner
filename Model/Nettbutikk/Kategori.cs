using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Nettbutikk.Model
{
    public class Kategori
    {
        [ScaffoldColumn(false)]
        public int kategoriId { get; set; }
        [Display(Name = "Kategori")]
        public string navn { get; set; }
    }
}