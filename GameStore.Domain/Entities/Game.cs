using GameStore.Domain.Interfaces;

namespace GameStore.Domain.Entities
{
    public class Game : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; } 
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }

        public ICollection<Genre> Genres { get; set; } = new List<Genre>();
    }
}
