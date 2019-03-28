using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ANightsTaleUI.Models
{
	public class Item
	{

		public int ItemID { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		public string Description { get; set; }

		[Required]
        [Range(0.0, 30.0,ErrorMessage = "The value must be greater tha 0")]
        public int Type { get; set; }

        [Range(0.0, 30.0, ErrorMessage = "The value must be greater tha 0")]
        public int? AC { get; set; }

        [Range(0.0, 30.0, ErrorMessage = "The value must be greater tha 0")]
        public int? NumDice { get; set; }

        [Range(0.0, 30.0, ErrorMessage = "The value must be greater tha 0")]
        public int? NumSides { get; set; }

        [Range(0.0, 30.0, ErrorMessage = "The value must be greater tha 0")]
        public int? Mods { get; set; }

		[Required]
		public string Effects { get; set; }
	}
}
