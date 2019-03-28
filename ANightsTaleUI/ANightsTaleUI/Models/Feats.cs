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

        [Range(0.0, 30.0, ErrorMessage = "The value must be greater tha 0")]
        public int Mods { get; set; }
	}
}
