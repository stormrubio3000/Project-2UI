using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ANightsTaleUI.Models
{
	public class Abilities
	{
		[Required]
		public string Name { get; set; }

		[Required]
		public string Description { get; set; }


		public int? NumDice { get; set; }


		public int? NumSides { get; set; }


		public bool? Attack { get; set; }

	}
}
