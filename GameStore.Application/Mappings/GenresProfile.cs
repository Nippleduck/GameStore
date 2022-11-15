using GameStore.Application.Models.Genres.DTOs;
using GameStore.Domain.Entities;
using AutoMapper;
using GameStore.Application.Models.Genres.Requests;

namespace GameStore.Application.Mappings
{
    public class GenresProfile : Profile
    {
        public GenresProfile()
        {
            CreateMap<Genre, GenreDTO>();

            CreateMap<AddGenreRequest, Genre>();
        }
    }
}
