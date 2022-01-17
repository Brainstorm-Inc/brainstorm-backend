using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Brainstorm.Entities.Project;

public class ProjectConfig : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.Property(o => o.Id)
            .HasColumnType($"uuid");

        builder.Property(u => u.Name).IsRequired();

        builder.HasOne(p => p.Org)
            .WithMany(o => o.Projects);

        builder.HasMany(u => u.Topics)
            .WithOne(t => t.Project);
    }
}