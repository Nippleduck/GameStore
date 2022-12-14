using GameStore.Common.Filtering.Models;
using GameStore.Domain.Entities;

namespace GameStore.Persistence.QueryFilters
{
    internal static class GameFilteringExtension
    {
        public static IQueryable<Game> Filter(this IQueryable<Game> source, GameFilter filter)
        {
            return source
                .FilterByName(filter.Name)
                .FilterByGenres(filter.Genres);
        }

        private static IQueryable<Game> FilterByName(this IQueryable<Game> source, string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return source;

            return source.Where(x => x.Name!.Contains(name));
        }

        private static IQueryable<Game> FilterByGenres(this IQueryable<Game> source, IEnumerable<Guid> genresIds)
        {
            if (!genresIds.Any()) return source;

            return source.Where(game => game.Genres.Any(genre => genresIds.Contains(genre.Id)));
        }
    }
}
