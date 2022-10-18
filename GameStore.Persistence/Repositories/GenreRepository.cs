using GameStore.Persistence.Repositories.Interfaces;
using GameStore.Persistence.Context;
using GameStore.Domain.Entities;

namespace GameStore.Persistence.Repositories
{
    public class GenreRepository : BaseGuidRepository<Genre>, IGenreRepository
    {
        public GenreRepository(ApplicationDbContext context) : base(context) { }
    }
}
