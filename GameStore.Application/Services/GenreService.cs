using GameStore.Application.Models.Genres.DTOs;
using GameStore.Application.Models.Genres.Requests;

namespace GameStore.Application.Services
{
    public class GenreService : BaseService, IGenreService
    {
        public GenreService(IUnitOfWork uof, IMapper mapper) : base(uof, mapper) { }

        public async Task<GenreDTO> AddAsync(AddGenreRequest request)
        {
            if (request is null) throw new ArgumentNullException(nameof(request));

            var genre = mapper.Map<Genre>(request);

            await uof.Genres.AddAsync(genre);
            await uof.SaveChangesAsync();

            return mapper.Map<GenreDTO>(genre);
        }

        public async Task<IEnumerable<GenreDTO>> GetAllAsync()
        {
            var genres = await uof.Genres.GetAllAsync();

            if (!genres.Any()) return Enumerable.Empty<GenreDTO>();

            return mapper.Map<IEnumerable<GenreDTO>>(genres);
        }

        public async Task<GenreDTO> GetByIdAsync(Guid id)
        {
            var genre = await uof.Genres.GetByIdAsync(id);

            if (genre is null) throw new NotFoundException(nameof(genre), id);

            return mapper.Map<GenreDTO>(genre); 
        }
    }
}
