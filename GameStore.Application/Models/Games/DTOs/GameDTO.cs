using GameStore.Application.Models.Genres.DTOs;

namespace GameStore.Application.Models.Games.DTOs
{
    public class GameDTO
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public GenreDTO[]? Genres { get; set; }
    }
}
