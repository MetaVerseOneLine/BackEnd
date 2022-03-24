using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace oneline.Repositories
{
    public class BaseRepository : IBaseRepository
    {
        public dynamic BaseResponse(int statuscode, string message)
        {
            IDictionary<string, object> base_response = new ExpandoObject();
            base_response.Add("statusCode", statuscode);
            base_response.Add("message", message);

            return base_response;
        }
    }
}
