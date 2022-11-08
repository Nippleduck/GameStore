using GameStore.Application.Models.Genres.DTOs;
using GameStore.Domain.Entities;
using AutoMapper;

namespace GameStore.Application.Mappings
{
    public class GenresProfile : Profile
    {
        public GenresProfile()
        {
            CreateMap<Genre, GenreDTO>();
        }
    }
}
