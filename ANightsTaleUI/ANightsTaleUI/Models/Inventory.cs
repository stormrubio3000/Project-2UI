using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ANightsTaleUI.Models
{
	public class Inventory
	{
		public int CharacterID { get; set; }


		public int ItemID { get; set; }

        [Range(0.0, 30.0, ErrorMessage = "The value must be greater tha 0")]
        public int Quantity { get; set; }


		public bool? ToggleE { get; set; }
	}
}
