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
		public int Type { get; set; }


		public int AC { get; set; }


		public int? NumDice { get; set; }


		public int? NumSides { get; set; }


		public int? Mods { get; set; }

		[Required]
		public string Effects { get; set; }
	}
}
