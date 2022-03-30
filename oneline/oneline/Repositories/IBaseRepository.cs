using Microsoft.AspNetCore.Mvc;
using oneline.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oneline.Repositories
{
    public interface IBaseRepository
    {
        dynamic BaseResponse(int statuscode, string message);
        bool WorldExist(int worldidx);
        bool UserExist(string userid);
        bool QuestExist(int questidx);
    }
}
