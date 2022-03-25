using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oneline.Dtos
{
    public class UserCreateDto
    {
        public string UserId { get; set; }
        public string UserPassword { get; set; }
        public string UserName { get; set; }
        public string UserContent { get; set; }
        public string UserImg { get; set; }
    }
}
