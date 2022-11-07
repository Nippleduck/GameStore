using GameStore.Application.Interfaces;
using GameStore.Persistence.UOF;

namespace GameStore.Application.Services
{
    public class GenreService : BaseService, IGenreService
    {
        public GenreService(IUnitOfWork uof) : base(uof) { }
    }
}
