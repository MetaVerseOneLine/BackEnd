using AutoMapper;
using oneline.Data;
using oneline.Dtos;
using oneline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oneline.Repositories
{
    public class WorldRepository : IWorldRepository
    {
        private readonly OneLineContext _context;
        private readonly IMapper _mapper;

        public WorldRepository(OneLineContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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

        public WorldDto WorldDetail(World world)
        {
            WorldDto detail = _mapper.Map<WorldDto>(world);
            return detail;
        }
    }
}
