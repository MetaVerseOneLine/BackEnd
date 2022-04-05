using Microsoft.AspNetCore.Mvc;
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
        bool ScoreExist(int worldidx, string userid);
        IDictionary<string, object> WorldRank(int worldidx);
        IDictionary<string, object> WorldRank5(int worldidx);
        List<IDictionary<string, object>> UserRank(string userid);
        int MyRank(int worldidx, string userid);
    }
}
