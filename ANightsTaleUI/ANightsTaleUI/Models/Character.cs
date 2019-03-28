using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ANightsTaleUI.Models
{
	public class Character
	{

		public int CharacterID { get; set; }
		public int UserId { get; set; }
        public int CampaignID { get; set; }
        public string CampaignName { get; set; }
        public string Race { get; set; }
        public string Class { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Bio")]
        public string Bio { get; set; }

        [Required]
        [Display(Name = "Race")]
        public int RaceID { get; set; }

        [Required]
        [Display(Name = "Class")]
        public int ClassID { get; set; }

        public List<int> MySkills { get; set; }
        public int Experience { get; set; }
		public int Level { get; set; }
		public int Str { get; set; }
		public int Dex { get; set; }
		public int Con { get; set; }
		public int Int { get; set; }
		public int Wis { get; set; }
		public int Cha { get; set; }
		public int Speed { get; set; }
		public int MaxHP { get; set; }
	}
}
