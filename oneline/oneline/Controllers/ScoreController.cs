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
    public class ScoreController : ControllerBase
    {
        private readonly IScoreRepository _scoreRepository;
        private readonly IBaseRepository _baseRepository;
        private readonly IMapper _mapper;
        public ScoreController(IScoreRepository scoreRepository, IBaseRepository baseRepository, IMapper mapper)
        {
            _scoreRepository = scoreRepository;
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        [HttpPost("Register")]
        public ActionResult Register([FromBody] ScoreRegDto score)
        {
            int worldidx = score.WorldIdx;
            string userid = score.UserId;
            if(!(_baseRepository.WorldExist(worldidx)))
            {
                return Ok(_baseRepository.BaseResponse(312, "World not exist"));
            }
            if (!(_baseRepository.UserExist(userid)))
            {
                return Ok(_baseRepository.BaseResponse(311, "User not exist"));
            }
            if(score == null)
            {
                return BadRequest();
            }
            Score nowscore = _mapper.Map<Score>(score);
            _scoreRepository.Register(nowscore);
            return Ok(_baseRepository.BaseResponse(201, "Success"));
        }

        [HttpGet("{userid}")]
        public ActionResult<List<IDictionary<string, object>>> UserRank(string userid)
        {
            if(_scoreRepository.UserRank(userid).Count() == 0)
            {
                return Ok(_baseRepository.BaseResponse(316, "No score data"));
            }
            else
            {
                return _scoreRepository.UserRank(userid);
            }
        }
    }
}
