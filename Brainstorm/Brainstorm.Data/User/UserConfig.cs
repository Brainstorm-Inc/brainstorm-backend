using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Brainstorm.Entities.User
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.Id).HasColumnType($"uuid");
            builder.Property(u => u.FirstName).IsRequired()
                                                  .HasDefaultValue("FirstName");
            builder.Property(u => u.LastName).IsRequired()
                                                 .HasDefaultValue("LastName");
            builder.Property(u => u.Email).IsRequired()
                                              .HasDefaultValue("first-last@mail.com");



            builder.Property(u => u.ProfilePicture).HasDefaultValue("https://robohash.org/first-last");
            builder.HasData(new User
            {
                FirstName ="Fname",
                LastName ="Lname", 
                Email="Fname-Lname@mail.com"
            });
        }
    }
}