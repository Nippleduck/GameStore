using GameStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameStore.Persistence.Context.Configurations
{
    internal class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder
                .Property(p => p.Name)
                .HasMaxLength(40)
                .IsRequired();

            builder
                .HasOne(p => p.ParentGenre)
                .WithMany(p => p.Subgenres)
                .HasForeignKey(p => p.ParentGenreId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
