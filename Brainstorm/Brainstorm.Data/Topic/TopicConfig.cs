using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Brainstorm.Entities.Topic;

public class TopicConfig : IEntityTypeConfiguration<Topic>
{
    public void Configure(EntityTypeBuilder<Topic> builder)
    {
        builder.Property(t => t.Id)
            .HasColumnType("uuid");

        builder.Property(t => t.Type).IsRequired();
        builder.Property(t => t.Title).IsRequired();
        builder.Property(t => t.CreationDate).IsRequired();

        builder.HasOne(t => t.Author).WithMany();
        builder.HasOne(t => t.HighlightedProposal).WithOne();
        builder.HasMany(t => t.Users);

        builder.HasMany(t => t.Iterations)
            .WithOne(i => i.Topic);
    }
}