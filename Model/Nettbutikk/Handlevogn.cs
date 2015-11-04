using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Model.Nettbutikk
{
    public class Handlevogn
    {
        [Display(Name ="Varer")]
        public List<HandlevognVare> varer { get; set; }
        [Display(Name = "Totalbeløp")]
        public decimal totalbelop { get; set; }
    }
}