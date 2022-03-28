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
        float AchievementTotal(string userid);
        IDictionary<string, object> AchievementGet(string userid);
    }
}
