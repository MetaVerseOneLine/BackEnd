using Microsoft.AspNetCore.Mvc;
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
            if (ScoreExist(score.WorldIdx, score.UserId))
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
                IDictionary<string, object> worldrank = WorldRank(world.WorldIdx);
                worldrank.Add("userId", userid);
                worldrank.Add("userName", _context.Users.FirstOrDefault(x => x.UserId == userid).UserName);
                worldrank.Add("score", world.MyScore);
                worldrank.Add("rank", MyRank(world.WorldIdx, userid));
                
                result.Add(worldrank);
            }
            return result;
        }
        public int MyRank(int worldidx, string userid)
        {
            List<Score> worldscore = _context.Scores.Where(x => x.WorldIdx == worldidx).ToList();
            worldscore = worldscore.OrderByDescending(x => x.MyScore).ThenBy(x => x.ScoreIdx).ToList();
            int myrank = 1;
            foreach(Score s in worldscore)
            {
                if(s.UserId == userid)
                {
                    break;
                }
                else
                {
                    myrank += 1;
                }
            }
            return myrank;

        }

        public IDictionary<string, object> WorldRank(int worldidx)
        {
            IDictionary<string, object> worldrank = new ExpandoObject();

            List<Score> worldscore = _context.Scores.Where(x => x.WorldIdx == worldidx).ToList();
            List<Score> top3 = new List<Score>();
            int[] top3score = { 0, 0, 0 };
            foreach(Score s in worldscore)
            {
                if(s.MyScore > top3score[2])
                {
                    top3score[2] = s.MyScore;
                    if(top3.Count == 3)
                    {
                        top3.RemoveAt(2);
                    }
                    top3.Add(s);
                    // 마지막꺼 빼야하는데
                    top3 = top3.OrderByDescending(x => x.MyScore).ThenBy(x => x.ScoreIdx).ToList();
                    Array.Sort(top3score);
                    Array.Reverse(top3score);
                }
            }
            worldrank.Add("worldName", _context.Worlds.FirstOrDefault(x=>x.WorldIdx==worldidx).WorldName);
            if(top3.Count >= 1)
            {
                worldrank.Add("firstUserId", top3[0].UserId);
                worldrank.Add("firstUserName", _context.Users.FirstOrDefault(x=>x.UserId == top3[0].UserId).UserName);
                worldrank.Add("firstScore", top3[0].MyScore);
            }
            else
            {
                worldrank.Add("message", "no rank data");
            }

            if(top3.Count >= 2)
            {
                worldrank.Add("secondUserId", top3[1].UserId);
                worldrank.Add("secondUserName", _context.Users.FirstOrDefault(x => x.UserId == top3[1].UserId).UserName);
                worldrank.Add("secondScore", top3[1].MyScore);
            }
            if(top3.Count >= 3)
            {
                worldrank.Add("thirdUserId", top3[2].UserId);
                worldrank.Add("thirdUserName", _context.Users.FirstOrDefault(x => x.UserId == top3[2].UserId).UserName);
                worldrank.Add("thirdScore", top3[2].MyScore);
            }
            return worldrank;
        }

        public IDictionary<string, object> WorldRank5(int worldidx)
        {
            IDictionary<string, object> worldrank = new ExpandoObject();

            List<Score> worldscore = _context.Scores.Where(x => x.WorldIdx == worldidx).ToList();
            List<Score> top5 = new List<Score>();
            int[] top5score = { 0, 0, 0, 0, 0 };
            foreach (Score s in worldscore)
            {
                if (s.MyScore > top5score[4])
                {
                    top5score[4] = s.MyScore;
                    if (top5.Count == 5)
                    {
                        top5.RemoveAt(4);
                    }
                    top5.Add(s);
                    // 마지막꺼 빼야하는데
                    top5 = top5.OrderByDescending(x => x.MyScore).ThenBy(x => x.ScoreIdx).ToList();
                    Array.Sort(top5score);
                    Array.Reverse(top5score);
                }
            }
            worldrank.Add("worldName", _context.Worlds.FirstOrDefault(x => x.WorldIdx == worldidx).WorldName);
            if (top5.Count >= 1)
            {
                worldrank.Add("firstUserId", top5[0].UserId);
                worldrank.Add("firstUserName", _context.Users.FirstOrDefault(x => x.UserId == top5[0].UserId).UserName);
                worldrank.Add("firstScore", top5[0].MyScore);
            }
            else
            {
                worldrank.Add("message", "no rank data");
            }

            if (top5.Count >= 2)
            {
                worldrank.Add("secondUserId", top5[1].UserId);
                worldrank.Add("secondUserName", _context.Users.FirstOrDefault(x => x.UserId == top5[1].UserId).UserName);
                worldrank.Add("secondScore", top5[1].MyScore);
            }
            if (top5.Count >= 3)
            {
                worldrank.Add("thirdUserId", top5[2].UserId);
                worldrank.Add("thirdUserName", _context.Users.FirstOrDefault(x => x.UserId == top5[2].UserId).UserName);
                worldrank.Add("thirdScore", top5[2].MyScore);
            }
            if (top5.Count >= 4)
            {
                worldrank.Add("forthUserId", top5[3].UserId);
                worldrank.Add("forthUserName", _context.Users.FirstOrDefault(x => x.UserId == top5[3].UserId).UserName);
                worldrank.Add("forthScore", top5[3].MyScore);
            }
            if (top5.Count >= 5)
            {
                worldrank.Add("fifthUserId", top5[4].UserId);
                worldrank.Add("fifthUserName", _context.Users.FirstOrDefault(x => x.UserId == top5[4].UserId).UserName);
                worldrank.Add("fifthScore", top5[4].MyScore);
            }
            return worldrank;
        }
    }
}
