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
            int worldidx = ach.WorldIdx;
            int questidx = ach.QuestIdx;
            string userid = ach.UserId;

            if (ach == null) return BadRequest();
            if (!(_baseRepository.WorldExist(worldidx))) return Ok(_baseRepository.BaseResponse(312, "World not exist"));
            if (!(_baseRepository.UserExist(userid))) return Ok(_baseRepository.BaseResponse(311, "User not exist"));
            if (!(_baseRepository.QuestExist(questidx))) return Ok(_baseRepository.BaseResponse(313, "Quest not exist"));
            if (_achievementRepository.AchievementExist(questidx, userid)) return Ok(_baseRepository.BaseResponse(314, "Already finish this quest"));
            if (!(_achievementRepository.QuestCheck(questidx, worldidx))) return Ok(_baseRepository.BaseResponse(315, "Quest - World not matched"));

            Achievement nowach = _mapper.Map<Achievement>(ach);
            _achievementRepository.Register(nowach);
            return Ok(_baseRepository.BaseResponse(201, "Success"));
        }

        [HttpPost("Quest")]
        public ActionResult<List<QuestDto>> UndoQeust(AchievementDto info)
        {
            int worldidx = info.WorldIdx;
            string userid = info.UserId;
            if (!(_baseRepository.WorldExist(worldidx)))
            {
                return Ok(_baseRepository.BaseResponse(312, "World not exist"));
            }
            if (!(_baseRepository.UserExist(userid)))
            {
                return Ok(_baseRepository.BaseResponse(311, "User not exist"));
            }
            if (_achievementRepository.UndoQuest(info.UserId, info.WorldIdx).Count() == 0)
            {
                return Ok(_baseRepository.BaseResponse(202, "Quest all done"));
            }
            else
            {
                return _achievementRepository.UndoQuest(info.UserId, info.WorldIdx);
            }
        }

        [HttpGet("{userid}")]
        public ActionResult<IDictionary<string, object>> AchievementGet(string userid)
        {
            if (!(_baseRepository.UserExist(userid)))
            {
                return Ok(_baseRepository.BaseResponse(311, "User not exist"));
            }

            return Ok(_achievementRepository.AchievementGet(userid));
        }
    }
}
