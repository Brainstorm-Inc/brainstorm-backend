using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Brainstorm.Entities.Rating;

public class RatingConfig : IEntityTypeConfiguration<Rating>
{
    public void Configure(EntityTypeBuilder<Rating> builder)
    {
        builder.Property(r => r.Id)
            .HasColumnType("uuid");

        builder.Property(r => r.Ones)
            .IsRequired();

        builder.Property(r => r.Twos)
            .IsRequired();

        builder.Property(r => r.Threes)
            .IsRequired();

        builder.Property(r => r.Fours)
            .IsRequired();

        builder.Property(r => r.Fives)
            .IsRequired();

        builder.Property(r => r.Avg)
            .IsRequired();
    }
}