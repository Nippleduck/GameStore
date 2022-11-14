using GameStore.Application.Models.Genres.DTOs;

namespace GameStore.Application.Interfaces
{
    public interface IGenreService
    {
        Task<IEnumerable<GenreDTO>> GetAllAsync();
        Task<GenreDTO> GetByIdAsync(Guid id);
        Task<GenreDTO> AddAsync(GenreDTO genreDTO);
    }
}
