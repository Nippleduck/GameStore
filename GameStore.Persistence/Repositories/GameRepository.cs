using GameStore.Persistence.Repositories.Interfaces;
using GameStore.Persistence.QueryFilters;
using GameStore.Persistence.Context;
using GameStore.Common.Filtering.Models;
using GameStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Persistence.Repositories
{
    public class GameRepository : BaseGuidRepository<Game>, IGameRepository
    {
        public GameRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Game>> GetAllByGenreIdAsync(Guid genreId)
        {
            return await Entities
                .AsNoTracking()
                .Include(game => game.Genres)
                .Where(game => game.Genres.Any(genre => genre.Id == genreId))
                .ToListAsync();
        }

        public async Task<IEnumerable<Game>> GetAllWithDetailsAsync()
        {
            return await Entities
                .AsNoTracking()
                .Include(game => game.Genres)
                .ToListAsync();
        }

        public async Task<IEnumerable<Game>> GetAllWithFilterAsync(GameFilter filter)
        {
            return await Entities
                .AsNoTracking()
                .Include(game => game.Genres)
                .Filter(filter)
                .ToListAsync();
        }

        public async Task<Game?> GetByIdWithDetailsAsync(Guid id)
        {
            return await Entities
                .AsNoTracking()
                .Include(game => game.Genres)
                .FirstOrDefaultAsync(game => game.Id == id);
        }
    }
}
