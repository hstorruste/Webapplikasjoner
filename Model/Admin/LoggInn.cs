using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Admin
{
    public class LoggInn
    {
        [Required]
        [Display(Name = "Brukernavn")]
        public string Brukernavn { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Passord")]
        public string passord { get; set; }
    }
}
