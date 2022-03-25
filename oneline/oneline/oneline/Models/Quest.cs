using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace oneline.Models
{
    public class Quest
    {
        [Key]
        public int QeustIdx { get; set; }

        public int WorldIdx { get; set; }
        public string QuestContent { get; set; }
        public World World { get; set; }
        public ICollection<Achievement> Achievements { get; set; }

    }
}
