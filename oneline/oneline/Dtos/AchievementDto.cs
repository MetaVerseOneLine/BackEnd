using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oneline.Dtos
{
    public class AchievementDto
    {
        public string UserId { get; set; }
        public int WorldIdx { get; set; }
        public int QuestIdx { get; set; }
    }
}
