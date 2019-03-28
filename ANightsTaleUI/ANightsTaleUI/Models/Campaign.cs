using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ANightsTaleUI.Models
{
	public class Campaign
	{
		public int CampaignID { get; set; }

		[Required]
		[Display(Name = "Campaign Name")]
		public string Name { get; set; }

        public IEnumerable<Info> infos { get; set; }
    }
}
