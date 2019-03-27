using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ANightsTaleUI.Models.ViewModels
{
	public class ItemInv
	{
		public List<Item> items { get; set; }

		public Item item { get; set; }

		public Inventory inventory {get; set;}

		[Required]
		public int charID { get; set; }

		[Required]
		public int quantity { get; set; }

		[Required]
		public int itemid { get; set; }

		[Required]
		public bool toggle { get; set; }

		
	}
}
