namespace GameStore.Application.Models.Genres.DTOs
{
    public class GenreDTO
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Guid ParentGenreId { get; set; }
    }
}
