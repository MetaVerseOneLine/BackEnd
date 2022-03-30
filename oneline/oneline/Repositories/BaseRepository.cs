using Microsoft.AspNetCore.Mvc;
using oneline.Data;
using oneline.Dtos;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace oneline.Repositories
{
    public class BaseRepository : IBaseRepository
    {
        private readonly OneLineContext _context;
        public BaseRepository(OneLineContext context)
        {
            _context = context;
        }
        public dynamic BaseResponse(int statuscode, string message)
        {
            IDictionary<string, object> base_response = new ExpandoObject();
            base_response.Add("statusCode", statuscode);
            base_response.Add("message", message);

            return base_response;
        }

        public bool QuestExist(int questidx)
        {
            if (_context.Quests.FirstOrDefault(x => x.QuestIdx == questidx) == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool UserExist(string userid)
        {
            if (_context.Users.FirstOrDefault(x => x.UserId == userid) == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool WorldExist(int worldidx)
        {
            if (_context.Worlds.FirstOrDefault(x => x.WorldIdx == worldidx) == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
