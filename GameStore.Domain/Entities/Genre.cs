using GameStore.Domain.Interfaces;

namespace GameStore.Domain.Entities
{
    public class Genre : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }

        public Guid ParentGenreId { get; set; }
        public Genre? ParentGenre { get; set; }

        public ICollection<Genre>? Subgenres { get; set; }
        public ICollection<Game>? Games { get; set; }
    }
}
