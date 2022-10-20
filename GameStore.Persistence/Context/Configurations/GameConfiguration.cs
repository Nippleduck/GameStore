using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using GameStore.Domain.Entities;

namespace GameStore.Persistence.Context.Configurations
{
    internal class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder
                .Property(p => p.Name)
                .HasMaxLength(60)
                .IsRequired();

            builder
                .Property(p => p.Description)
                .HasMaxLength(1000)
                .IsRequired();

            builder
                .HasMany(p => p.Genres)
                .WithMany(p => p.Games)
                .UsingEntity<Dictionary<string, object>>(
                    "GamesToGenres",
                    right => right
                        .HasOne<Genre>()
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .HasConstraintName("FK_GamesToGenres_Genres_GenreId")
                        .OnDelete(DeleteBehavior.Cascade),
                    left => left
                        .HasOne<Game>()
                        .WithMany()
                        .HasForeignKey("GameId")
                        .HasConstraintName("FK_GamesToGenres_Games_GameId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                );
        }
    }
}
