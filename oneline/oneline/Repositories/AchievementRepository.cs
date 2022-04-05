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
    public class AchievementRepository : IAchievementRepository
    {
        private readonly OneLineContext _context;
        private readonly IMapper _mapper;
        public AchievementRepository(OneLineContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool AchievementExist(int questidx, string userid)
        {
            if (_context.Achievements.Where(x=>x.UserId == userid).FirstOrDefault(x => x.QuestIdx == questidx) == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public IDictionary<string, object> AchievementGet(string userid)
        {
            IDictionary<string, object> result = new ExpandoObject();

            result.Add("doneQuest", DoQuest(userid));
            result.Add("total", AchievementTotal(userid));

            return result;
        }

        public float AchievementTotal(string userid)
        {
            List<Quest> allquest = _context.Quests.ToList();
            if (_context.Achievements.FirstOrDefault(x => x.UserId == userid) != null)
            {
                List<Achievement> myquest = _context.Achievements.Where(x => x.UserId == userid).ToList();

                float result = ((float)myquest.Count() / allquest.Count()) * 100;
                return result;
            }
            else return 0;
        }

        public List<IDictionary<string, object>> DoQuest(string userid)
        {
            List<IDictionary<string,object>> result = new List<IDictionary<string, object>>();
            List<Achievement> did = _context.Achievements.Where(x => x.UserId == userid).ToList();
            foreach(Achievement d in did)
            {
                IDictionary<string, object> temp = new ExpandoObject();
                string questcontent = _context.Quests.Where(x => x.WorldIdx == d.WorldIdx).FirstOrDefault(x => x.QuestIdx == d.QuestIdx).QuestContent;
                temp.Add("questContent", questcontent);
                
                result.Add(temp);
            }
            return result;
        }

        public bool QuestCheck(int questidx, int worldidx)
        {
            if (_context.Quests.FirstOrDefault(x => x.QuestIdx == questidx).WorldIdx == worldidx)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Register(Achievement achievement)
        {
            _context.Achievements.Add(achievement);
            /*
            List<Achievement> worldach = _context.Achievements.Where(x => x.WorldIdx == achievement.WorldIdx).ToList();
            
            if (_context.Achievements.Where(x => x.WorldIdx == achievement.WorldIdx).FirstOrDefault(x=>x.UserId == achievement.UserId) == null){
            }
            */
            _context.SaveChanges();
        }
        
        public List<QuestDto> UndoQuest(string userid, int worldidx)
        {
            List<Quest> allquest = _context.Quests.Where(x => x.WorldIdx == worldidx).ToList();
            List<Achievement> donequest = _context.Achievements.Where(x => x.WorldIdx == worldidx).Where(x => x.UserId == userid).ToList();
            List<QuestDto> result = new List<QuestDto>();
            foreach(Quest quest in allquest)
            {
                if(donequest.Find(x=>x.QuestIdx == quest.QuestIdx) == null)
                {
                    QuestDto temp = _mapper.Map<QuestDto>(quest);
                    result.Add(temp);
                }
            }
            return result;
        }
    }
}
