using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ANightsTaleUI.Models
{
	public class Feats
	{
		public int FeatID { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		public string Description { get; set; }

		[Required]
		public bool StatTable { get; set; }

		[Required]
		public int StatType { get; set; }


		public int Mods { get; set; }
	}
}
