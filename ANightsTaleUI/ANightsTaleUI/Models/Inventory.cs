using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ANightsTaleUI.Models
{
	public class Inventory
	{
		public int CharacterID { get; set; }


		public int ItemID { get; set; }


		public int Quantity { get; set; }


		public bool? ToggleE { get; set; }
	}
}
