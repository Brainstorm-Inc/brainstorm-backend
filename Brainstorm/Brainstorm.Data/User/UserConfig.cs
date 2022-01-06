using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Brainstorm.Entities.User;

public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasIndex(u => u.Email)
            .IsUnique();

        builder.Property(u => u.Id)
            .HasColumnType($"uuid");

        builder.Property(u => u.FirstName)
            .IsRequired()
            .HasDefaultValue("FirstName");

        builder.Property(u => u.LastName)
            .IsRequired()
            .HasDefaultValue("LastName");

        builder.Property(u => u.Email)
            .IsRequired()
            .HasDefaultValue("first-last@mail.com");

        builder.Property(s => s.Password)
            .IsRequired();

        builder.Property(u => u.ProfilePicture)
            .HasDefaultValue("https://robohash.org/first-last");

        builder.Property(u => u.Salt)
          .IsRequired();

        builder.HasData(
            new User
            {
                Id = Guid.NewGuid(),
                FirstName = "test",
                LastName = "test",
                Email = "test@test.ro",
                Password = "password",
                Salt = ""
            });
    }
}
