using GameStore.Common.Filtering.Models;
using GameStore.Domain.Entities;

namespace GameStore.Persistence.Repositories.Interfaces
{
    public interface IGameRepository : IGuidRepository<Game> 
    {
        Task<IEnumerable<Game>> GetAllWithFilterAsync(GameFilter filter);
        Task<IEnumerable<Game>> GetAllWithDetailsAsync();
        Task<IEnumerable<Game>> GetAllByGenreIdAsync(Guid genreId);
        Task<Game?> GetByIdWithDetailsAsync(Guid id);
    }
}
