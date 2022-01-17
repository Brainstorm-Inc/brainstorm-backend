using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Brainstorm.Entities.Comment;

public class CommentConfig : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.Property(c => c.Id)
            .HasColumnType("uuid");

        builder.Property(c => c.Content)
            .IsRequired();

        builder.Property(c => c.CreationDate)
            .IsRequired();

        builder.HasOne(c => c.Author).WithMany();
        builder.HasOne(c => c.ReplyTo).WithMany();
    }
}