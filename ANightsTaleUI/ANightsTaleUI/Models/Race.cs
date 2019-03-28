using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ANightsTaleUI.Models
{
    public class Race
    {
        public int RaceID { get; set; }

        [Display(Name = "Race")]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
