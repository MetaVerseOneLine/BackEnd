using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using oneline.Dtos;
using oneline.Models;
using oneline.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oneline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AchievementController : ControllerBase
    {
        private readonly IAchievementRepository _achievementRepository;
        private readonly IBaseRepository _baseRepository;
        private readonly IMapper _mapper;

        public AchievementController(IAchievementRepository achievementRepository, IBaseRepository baseRepository, IMapper mapper)
        {
            _achievementRepository = achievementRepository;
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        [HttpPost("Register")]
        public ActionResult Register([FromBody] AchievementDto ach)
        {
            if (ach == null)
            {
                Console.WriteLine("1");
                return BadRequest();
            }
            Achievement nowach = _mapper.Map<Achievement>(ach);
            Console.WriteLine("1-1");
            _achievementRepository.Register(nowach);
            return Ok(_baseRepository.BaseResponse(201, "Success"));
        }

        [HttpPost("Quest")]
        public ActionResult<List<QuestDto>> UndoQeust(AchievementDto info)
        {
            if (_achievementRepository.UndoQuest(info.UserId, info.WorldIdx) == null)
            {
                return _baseRepository.BaseResponse(202, "All done");
            }
            else
            {
                return _achievementRepository.UndoQuest(info.UserId, info.WorldIdx);
            }
        }

        [HttpGet("{userid}")]
        public IDictionary<string, object> AchievementGet(string userid)
        {
            return _achievementRepository.AchievementGet(userid);
        }
    }
}
