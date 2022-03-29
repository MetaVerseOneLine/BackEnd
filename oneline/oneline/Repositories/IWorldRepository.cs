using oneline.Dtos;
using oneline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oneline.Repositories
{
    public interface IWorldRepository
    {
        WorldDto WorldDetail(World world);
        List<WorldListDto> GetAllWorld();
        World GetWorld(int worldidx);
    }
}
