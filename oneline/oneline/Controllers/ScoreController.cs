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
            if(score == null)
            {
                return BadRequest();
            }
            Score nowscore = _mapper.Map<Score>(score);
            _scoreRepository.Register(nowscore);
            return Ok(_baseRepository.BaseResponse(201, "Success"));
        }

        [HttpPost("User_Rank")]
        public ActionResult<List<IDictionary<string, object>>> UserRank([FromBody] ScoreRegDto score)
        {
            if(_scoreRepository.UserRank(score.UserId) == null)
            {
                return _baseRepository.BaseResponse(202, "no score data");
            }
            else
            {
                return _scoreRepository.UserRank(score.UserId);
            }
        }
    }
}
