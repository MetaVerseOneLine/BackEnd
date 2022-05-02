using oneline.Dtos;
using oneline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oneline.Repositories
{
    public interface IAchievementRepository
    {
        void Register(Achievement achievement);
        List<QuestDto> UndoQuest(string userid, int worldidx);
        List<IDictionary<string, object>> DoQuest(string userid);
        List<IDictionary<string, object>> DoneQuest(string userid, int worldidx);
        float AchievementTotal(string userid);
        IDictionary<string, object> AchievementGet(string userid);
        bool AchievementExist(int questidx, string userid);
        bool QuestCheck(int questidx, int worldidx);
    }
}
