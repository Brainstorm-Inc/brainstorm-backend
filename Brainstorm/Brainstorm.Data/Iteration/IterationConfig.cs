using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Brainstorm.Entities.Iteration;

public class IterationConfig : IEntityTypeConfiguration<Iteration>
{
    public void Configure(EntityTypeBuilder<Iteration> builder)
    {
        builder.Property(i => i.Id)
            .HasColumnType("uuid");

        builder.Property(i => i.Position)
            .IsRequired();

        builder.Property(i => i.IsOpen)
            .IsRequired();

        builder.Property(i => i.Goal)
            .IsRequired();

        builder.Property(i => i.Description)
            .IsRequired();

        builder.Property(i => i.Deadline)
            .IsRequired();

        builder.HasMany(i => i.Comments).WithOne();
        builder.HasOne(i => i.Timeline).WithMany();
    }
}