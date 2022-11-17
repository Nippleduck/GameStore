using GameStore.Application.External.MediaStorage;
using GameStore.Application.Models.Games.DTOs;
using GameStore.Application.Models.Games.Requests;
using GameStore.Common.Filtering.Models;

namespace GameStore.Application.Services
{
    public class GameService : BaseService, IGameService
    {
        public GameService(IUnitOfWork uof, IMapper mapper, IExternalMediaStorage mediaStorage) 
            : base(uof, mapper) 
        {
            this.mediaStorage = mediaStorage;
        }

        private readonly IExternalMediaStorage mediaStorage;

        public async Task<GameDTO> AddAsync(SetGameDetailsRequest request)
        {
            if (request is null) throw new ArgumentNullException(nameof(request));

            var game = mapper.Map<Game>(request);

            await AddGenresToGameAsync(request.GenreIds, game);

            await uof.Games.AddAsync(game);
            await uof.SaveChangesAsync();

            return mapper.Map<GameDTO>(game);
        }

        public async Task<GameDTO> GetByIdAsync(Guid id)
        {
            var game = await uof.Games.GetByIdWithDetailsAsync(id);

            if (game is null) throw new NotFoundException(nameof(game), id);

            return mapper.Map<GameDTO>(game);
        }

        public async Task<IEnumerable<GameDTO>> GetForSaleAsync(GameFilter filter)
        {
            var games = await uof.Games.GetAllWithFilterAsync(filter);

            if (!games.Any()) return Enumerable.Empty<GameDTO>();
            
            return mapper.Map<IEnumerable<GameDTO>>(games);
        }

        public async Task DeleteByIdAsync(Guid id)
        {
            var deleted = await uof.Games.DeleteByIdAsync(id);

            if (!deleted) throw new NotFoundException(nameof(Game), id);

            await uof.SaveChangesAsync();
        }

        public async Task UpdateAsync(Guid id, SetGameDetailsRequest request)
        {
            if (request is null) throw new ArgumentNullException(nameof(request));

            var game = await uof.Games.GetByIdWithDetailsAsync(id);

            if (game is null) throw new NotFoundException(nameof(game), id);

            mapper.Map(request, game);

            await UpdateGenresAsync(request.GenreIds, game);

            uof.Games.Update(game);
            await uof.SaveChangesAsync();
        }

        private async Task UpdateGenresAsync(IEnumerable<Guid> genresIds, Game game)
        {
            var difference = game.Genres.ExceptBy(genresIds, game => game.Id);

            foreach (var genre in difference.ToArray())
            {
                game.Genres.Remove(genre);
            }

            var newGenres = genresIds.Except(game.Genres.Select(genre => genre.Id));

            if (newGenres.Any()) await AddGenresToGameAsync(newGenres.ToArray(), game);
        }

        private async Task AddGenresToGameAsync(IEnumerable<Guid> genresIds, Game game)
        {
            foreach (var genreId in genresIds.Distinct())
            {
                var genre = await uof.Genres.GetByIdAsync(genreId);

                if (genre is null) throw new NotFoundException(nameof(genre), genreId);

                game.Genres.Add(genre);
            }
        }

        public async Task UpdateImageAsync(Guid id, Stream image, string name)
        {
            var game = await uof.Games.GetByIdAsync(id);
            
            if (game is null) throw new NotFoundException(nameof(game), id);

            var imageUrl = await mediaStorage.UploadImageAsync(image, name, FolderNames.Games);
            game.ImageUrl = imageUrl;

            uof.Games.Update(game);
            await uof.SaveChangesAsync();
        }
    }
}
