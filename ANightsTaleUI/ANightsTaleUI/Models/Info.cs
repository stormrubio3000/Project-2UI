using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ANightsTaleUI.Models
{
    public class Info
    {
        public int InfoID { get; set; }
        public int CampaignID { get; set; }
        [Required]
        [Display(Name = "Type")]
        public string Type { get; set; }
        [Required]
        [Display(Name = "Message")]
        public string Message { get; set; }
    }
}
