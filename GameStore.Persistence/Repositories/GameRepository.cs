using GameStore.Persistence.Repositories.Interfaces;
using GameStore.Persistence.Context;
using GameStore.Domain.Entities;

namespace GameStore.Persistence.Repositories
{
    public class GameRepository : BaseGuidRepository<Game>, IGameRepository
    {
        public GameRepository(ApplicationDbContext context) : base(context) { }

        public Task<IEnumerable<Game>> GetAllByGenreId(Guid genreId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Game>> GetAllWithDetails()
        {
            throw new NotImplementedException();
        }

        public Task<Game?> GetByIdWithDetails(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
