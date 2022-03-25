using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oneline.Repositories
{
    public interface IBaseRepository
    {
        dynamic BaseResponse(int statuscode, string message);
    }
}
