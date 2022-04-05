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
    public class WorldRepository : IWorldRepository
    {
        private readonly OneLineContext _context;
        private readonly IMapper _mapper;
        private readonly IAchievementRepository _achievementRepository;
        private readonly IScoreRepository _scoreRepository;

        public WorldRepository(OneLineContext context, IMapper mapper, IAchievementRepository achievementRepository, IScoreRepository scoreRepository)
        {
            _context = context;
            _mapper = mapper;
            _achievementRepository = achievementRepository;
            _scoreRepository = scoreRepository;
        }

        public List<WorldListDto> GetAllWorld()
        {
            List<World> worlds = _context.Worlds.ToList();
            List<WorldListDto> result = new List<WorldListDto>();
            foreach(World w in worlds)
            {
                WorldListDto worldlist = _mapper.Map<WorldListDto>(w);
                result.Add(worldlist);
            }
            return result;
        }

        public World GetWorld(int worldidx)
        {
            World world = _context.Worlds.FirstOrDefault(x => x.WorldIdx == worldidx);
            return world;
        }

        public IDictionary<string, object> WorldDetail(World world, string userid)
        {
            IDictionary<string, object> detail = new ExpandoObject();
            detail.Add("worldIdx", world.WorldIdx);
            detail.Add("worldName", world.WorldName);
            detail.Add("worldContent", world.WorldContent);
            detail.Add("worldScene", world.WorldScene);
            detail.Add("worldCategory", world.WorldCategory);
            detail.Add("worldImg", world.WorldImg);


            if (world.WorldCategory == "edu")
            {
                List<IDictionary<string, object>> questlist = _achievementRepository.DoQuest(userid);
                if(questlist.Count() == 0)
                {
                    detail.Add("DoneQuest", "AllDone");
                }
                else
                {
                    detail.Add("DoneQuest", questlist);
                }

            }
            else if (world.WorldCategory == "game")
            {
                detail.Add("worldRank5", _scoreRepository.WorldRank5(world.WorldIdx));
            }
            return detail;
        }
    }
}
