using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ANightsTaleUI.Models
{
    public class Skill
    {
        public int Id { get; set; }

		[Required]
        [Display(Name="Choose from available skills:")]
        public string Name { get; set; }
    }
}
