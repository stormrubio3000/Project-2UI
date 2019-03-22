using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ANightsTaleUI.Models
{
	public class Campaign
	{
		[Required]
		[Display(Name = "Campaign Name")]
		public string Name { get; set; }

	}
}
