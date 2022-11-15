using GameStore.Application.Models.Genres.DTOs;
using GameStore.Application.Models.Genres.Requests;

namespace GameStore.Application.Interfaces
{
    public interface IGenreService
    {
        Task<IEnumerable<GenreDTO>> GetAllAsync();
        Task<GenreDTO> GetByIdAsync(Guid id);
        Task<GenreDTO> AddAsync(AddGenreRequest request);
    }
}
