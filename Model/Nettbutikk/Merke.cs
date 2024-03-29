﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Model.Nettbutikk
{
    public class Merke
    {
        [ScaffoldColumn(false)]
        public int merkeId { get; set; }
        [Display(Name = "Merke")]
        [Required(ErrorMessage = "Navn på merke må oppgis")]
        public string navn { get; set; }
        [Display(Name = "Antall sko")]
        public int antallSko { get; set; }
    }
}
