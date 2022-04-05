using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using oneline.Dtos;
using oneline.Models;
using oneline.Repositories;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace oneline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IBaseRepository _baseRepository;
        private readonly IMapper _mapper;
        public UserController(IUserRepository userRepository, IBaseRepository baseRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        [HttpPost("Login")]
        public ActionResult Login([FromBody] UserLoginDto input)
        {
            if(input == null)
            {
                return BadRequest();
            }
            
            return Ok(_userRepository.Login(input));

        }

        [HttpPost("Join")]
        public ActionResult Signup([FromBody] UserCreateDto input)
        {
            if (input == null)
            {
                return BadRequest();
            }
            if (_userRepository.DupCheck(input.UserId))
            {
                return Ok(_baseRepository.BaseResponse(317, "Id already exist"));
            }
            else
            {
                User toAdd = _mapper.Map<User>(input);
                _userRepository.Join(toAdd);
                return Ok(_baseRepository.BaseResponse(201, "Success"));
            }
        }


        [HttpPost("Check")]
        public ActionResult Check([FromBody] UserLoginDto input)
        {
            if (_userRepository.DupCheck(input.UserId))
                return Ok(_baseRepository.BaseResponse(317, "Id already exist"));
            else
                return Ok(_baseRepository.BaseResponse(201, "Success"));
        }

        [HttpGet("{userid}")]
        public ActionResult<UserInfoDto> GetUserInfo(string userid)
        {
            User userinfo = _userRepository.GetUserInfo(userid);
            UserInfoDto user = _mapper.Map<UserInfoDto>(userinfo);
            if(user == null)
            {
                return NotFound();
            }
            return user;
        }
    }
}
