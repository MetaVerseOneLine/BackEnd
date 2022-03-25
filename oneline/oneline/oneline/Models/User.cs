using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace oneline.Models
{
    public class User
    {
        [Key]
        public string UserId { get; set; }

        public string UserPassword { get; set; }
        public string UserName { get; set; }
        public string UserContent { get; set; }
        public string UserImg { get; set; }
        public ICollection<Score> Scores { get; set; }
        public ICollection<Achievement> Achievements { get; set; }
    }
}
