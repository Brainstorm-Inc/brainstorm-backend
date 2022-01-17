using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Brainstorm.Entities.Proposal;

public class ProposalConfig : IEntityTypeConfiguration<Proposal>
{
    public void Configure(EntityTypeBuilder<Proposal> builder)
    {
        builder.Property(t => t.Id)
            .HasColumnType("uuid");

        builder.Property(p => p.Description)
            .IsRequired();

        builder.Property(p => p.CreationDate)
            .IsRequired();

        builder.HasOne(p => p.Rating).WithOne();
        builder.HasOne(p => p.Author).WithMany();
        builder.HasMany(p => p.Comments)
            .WithOne(c => c.Proposal);
    }
}