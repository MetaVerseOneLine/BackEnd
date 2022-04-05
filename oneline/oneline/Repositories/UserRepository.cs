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

        public UserRepository(OneLineContext context)
        {
            _context = context;
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
            if (DupCheck(user.UserId)) // id 존재하면
            {
                if (dbUser.UserPassword != user.UserPassword) // id 있는데 password 틀리면
                {
                    base_response.Add("statusCode", 318);
                    base_response.Add("message", "PW not matched");
                }
                else
                {
                    base_response.Add("statusCode", 201);
                    base_response.Add("message", "Success");
                    base_response.Add("userId", user.UserId);

                }
            }
            else
            {
                base_response.Add("statusCode", 311);
                base_response.Add("message", "User not exist");
            }

            return base_response;
        }
    }
}
