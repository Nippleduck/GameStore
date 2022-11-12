namespace GameStore.Application.Models.Games.Requests
{
    public class SetGameDetailsRequest
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public IEnumerable<Guid> GenreIds { get; set; } = Enumerable.Empty<Guid>();
    }
}
