using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Brainstorm.Entities.Timeline;

public class TimelineConfig : IEntityTypeConfiguration<Timeline>
{
    public void Configure(EntityTypeBuilder<Timeline> builder)
    {
        builder.Property(t => t.Id)
            .HasColumnType("uuid");

        builder.HasMany(t => t.Proposals)
            .WithOne();
    }
}