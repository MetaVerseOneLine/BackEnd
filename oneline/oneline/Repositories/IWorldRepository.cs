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
        IDictionary<string, object> WorldDetail(World world, string userid);
        List<WorldListDto> GetAllWorld();
        World GetWorld(int worldidx);
    }
}
