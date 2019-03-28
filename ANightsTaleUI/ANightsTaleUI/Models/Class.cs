using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ANightsTaleUI.Models
{
    public class Class
    {
        public int ClassID { get; set; }

        [Display(Name = "Class")]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
