using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using oneline.Dtos;
using oneline.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oneline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorldController : ControllerBase
    {
        private readonly IWorldRepository _worldRepository;
        private readonly IBaseRepository _baseRepository;
        private readonly IMapper _mapper;

        public WorldController(IWorldRepository worldRepository, IBaseRepository baseRepository, IMapper mapper)
        {
            _worldRepository = worldRepository;
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        [HttpGet("{worldidx}")]
        public ActionResult<WorldDto> WorldDetail(int worldidx)
        {
            if(worldidx == null)
            {
                return BadRequest();
            }

            if(_worldRepository.GetWorld(worldidx) == null)
            {
                return BadRequest();
            }
            else
            {
                WorldDto detail = _worldRepository.WorldDetail(_worldRepository.GetWorld(worldidx));
                return detail;
            }
        }

        [HttpPost]
        public List<WorldListDto> GetAllWorld()
        {
            return _worldRepository.GetAllWorld();
        }
    }
}
