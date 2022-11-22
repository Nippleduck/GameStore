namespace GameStore.Common.Filtering.Models
{
    public class GameFilter
    {
        public string Name { get; set; } = string.Empty;
        public IEnumerable<Guid> Genres { get; set; } = Enumerable.Empty<Guid>();
    }
}
