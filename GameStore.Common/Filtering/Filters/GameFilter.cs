namespace GameStore.Common.Filtering.Filters
{
    public class GameFilter
    {
        public string Name { get; set; } = string.Empty;
        public IEnumerable<Guid> Genres { get; set; } = Enumerable.Empty<Guid>();
    }
}
