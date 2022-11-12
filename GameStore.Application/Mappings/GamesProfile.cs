using GameStore.Application.Models.Games.DTOs;
using GameStore.Application.Models.Games.Requests;
using GameStore.Domain.Entities;
using AutoMapper;

namespace GameStore.Application.Mappings
{
    public class GamesProfile : Profile
    {
        public GamesProfile()
        {
            CreateMap<Game, GameDTO>();

            CreateMap<SetGameDetailsRequest, Game>();
        }
    }
}
