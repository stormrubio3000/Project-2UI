using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ANightsTaleUI.Models.ViewModels
{
    public class CreateCharacterViewModel
    {
        public Character Character { get; set; }
        public List<int> MySkills { get; set; }

        public List<Race> Races { get; set; }
        public List<Class> Classes { get; set; }
        public List<int> Rolls { get; set; }
        public List<Skill> Skills { get; set; }
    }
}
