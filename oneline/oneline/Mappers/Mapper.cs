using AutoMapper;
using oneline.Dtos;
using oneline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oneline.Mappers
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<User, UserCreateDto>().ReverseMap();
            CreateMap<User, UserLoginDto>().ReverseMap();
            CreateMap<User, UserInfoDto>().ReverseMap();
            CreateMap<Score, ScoreRegDto>().ReverseMap();
            CreateMap<Achievement, AchievementDto>().ReverseMap();
            CreateMap<Quest, QuestDto>().ReverseMap();
            CreateMap<World, WorldDto>().ReverseMap();
            CreateMap<World, WorldListDto>().ReverseMap();
        }
    }
}
