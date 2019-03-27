using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ANightsTaleUI.Models.ViewModels
{
	public class AbilityChar
	{
		public List<Abilities> abilities { get; set; }

		public Abilities ability { get; set; }

		public int charID { get; set; }

		public int mod { get; set; }
	}
}
