using AutoMapper;
using oneline.Data;
using oneline.Dtos;
using oneline.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace oneline.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly OneLineContext _context;
        private readonly IMapper _mapper;
        public UserRepository(OneLineContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public bool DupCheck(string userid)
        {
            User checkUser = _context.Users.FirstOrDefault(x => x.UserId == userid);
            if (checkUser == null) return false; // 중복된 아이디 존재하지 않을 때
            else return true; // 중복된 아이디 존재할 때
        }

        public User GetUserInfo(string userid)
        {
            User userInfo = _context.Users.FirstOrDefault(x => x.UserId == userid);
            
            return userInfo;
        }

        public void Join(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
        
        public dynamic Login(UserLoginDto user)
        {
            IDictionary<string, object> base_response = new ExpandoObject();
            User dbUser = _context.Users.FirstOrDefault(x => x.UserId == user.UserId);
            if(DupCheck(user.UserId))
            {
                base_response.Add("statusCode", 202);
                base_response.Add("message", "id not exist");
            }
            else if (dbUser.UserPassword != user.UserPassword)
            {
                base_response.Add("statusCode", 203);
                base_response.Add("message", "pw not matched");
            }
            else
            {
                base_response.Add("statusCode", 201);
                base_response.Add("message", "Success");
                base_response.Add("Id", user.UserId);
            }

            return base_response;
        }
    }
}
