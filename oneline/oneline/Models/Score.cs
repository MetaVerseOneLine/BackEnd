using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace oneline.Models
{
    public class Score
    {
        [Key]
        public int ScoreIdx { get; set; }

        public string UserId { get; set; }
        public int WorldIdx { get; set; }
        public int MyScore { get; set; }
        public User User { get; set; }
        public World World { get; set; }

    }
}
