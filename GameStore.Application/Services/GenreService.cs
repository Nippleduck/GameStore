using AutoMapper;
using GameStore.Application.Interfaces;
using GameStore.Application.Models.Genres.DTOs;
using GameStore.Persistence.UOF;

namespace GameStore.Application.Services
{
    public class GenreService : BaseService, IGenreService
    {
        public GenreService(IUnitOfWork uof, IMapper mapper) : base(uof, mapper) { }

        public Task<GenreDTO> AddAsync(GenreDTO genreDTO)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GenreDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GenreDTO> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
