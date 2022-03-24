using oneline.Dtos;
using oneline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oneline.Repositories
{
    public interface IScoreRepository
    {
        void Register(Score score);
        int ScoreExist(int worldidx, string userid);
        IDictionary<string, object> WorldRank(int worldidx, string userid);
        List<IDictionary<string, object>> UserRank(string userid);
    }
}
