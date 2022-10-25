using GameStore.Persistence.Repositories.Interfaces;
using GameStore.Persistence.Context;
using GameStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Persistence.Repositories
{
    public class GameRepository : BaseGuidRepository<Game>, IGameRepository
    {
        public GameRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Game>> GetAllByGenreId(Guid genreId)
        {
            return await Entities
                .AsNoTracking()
                .Include(game => game.Genres)
                .Where(game => game.Genres.Any(genre => genre.Id == genreId))
                .ToListAsync();
        }

        public async Task<IEnumerable<Game>> GetAllWithDetails()
        {
            return await Entities
                .AsNoTracking()
                .Include(game => game.Genres)
                .ToListAsync();
        }

        public async Task<Game?> GetByIdWithDetails(Guid id)
        {
            return await Entities
                .AsNoTracking()
                .Include(game => game.Genres)
                .FirstOrDefaultAsync(game => game.Id == id);
        }
    }
}
