namespace GameStore.Application.Models.Genres.Requests
{
    public class AddGenreRequest
    {
        public string? Name { get; set; }
        public Guid ParentGenreId { get; set; }
    }
}
