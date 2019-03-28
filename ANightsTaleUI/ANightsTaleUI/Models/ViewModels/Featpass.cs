using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ANightsTaleUI.Models.ViewModels
{
	public class Featpass
	{
		public List<Feats> feats { get; set; }

		public Feats feat { get; set; }

		public int charID { get; set; }
		public int featId { get; set; }
	}
}
