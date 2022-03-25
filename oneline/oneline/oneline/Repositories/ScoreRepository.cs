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
    public class ScoreRepository : IScoreRepository
    {
        private readonly OneLineContext _context;
        public ScoreRepository(OneLineContext context)
        {
            _context = context;
        }
        public void Register(Score score)
        {
            if(ScoreExist(score.WorldIdx, score.UserId))
            {
                Score prior_score = _context.Scores.Where(x => x.WorldIdx == score.WorldIdx).FirstOrDefault(x => x.UserId == score.UserId);
                if(score.MyScore > prior_score.MyScore)
                {
                    prior_score.MyScore = score.MyScore;
                }
            }
            else
            {
                _context.Scores.Add(score);
            }
            _context.SaveChanges();

        }

        public Boolean ScoreExist(int worldidx, string userid)
        {
            Score score = _context.Scores.Where(x => x.UserId == userid).FirstOrDefault(x => x.WorldIdx == worldidx);
            if (score == null) return false;
            else return true;
        }

        public List<IDictionary<string, object>> UserRank(string userid)
        {
            List<IDictionary<string, object>> result = new List<IDictionary<string, object>>();
            List<Score> userrank = _context.Scores.Where(x => x.UserId == userid).ToList();
            if(userrank == null)
            {
                return null;
            }
            foreach(Score world in userrank)
            {
                result.Add(WorldRank(world.WorldIdx, userid));
            }
            return result;
        }

        public IDictionary<string, object> WorldRank(int worldidx, string userid)
        {
            IDictionary<string, object> worldrank = new ExpandoObject();

            Score score = _context.Scores.Where(x => x.UserId == userid).FirstOrDefault(x => x.WorldIdx == worldidx);
            worldrank.Add("UserId", userid);
            worldrank.Add("WorldIdx", worldidx);
            worldrank.Add("Score", score.MyScore);



            return worldrank;
        }
    }
}
