using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace oneline.Models
{
    public class World
    {
        [Key]
        public int WorldIdx { get; set; }

        public string WorldName { get; set; }
        public string WorldContent { get; set; }
        public int WorldScene { get; set; }
        public string WorldCategory { get; set; }
        public int WorldImg { get; set; }
        public ICollection<Score> Scores { get; set; }
        public ICollection<Achievement> Achievements { get; set; }
        public ICollection<Quest> Quests { get; set; }

    }
}
