using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Brainstorm.Entities.Organization;

public class OrganizationConfig : IEntityTypeConfiguration<Organization>
{
    public void Configure(EntityTypeBuilder<Organization> builder)
    {
        builder.HasIndex(o => o.Name);

        builder.Property(o => o.Id)
            .HasColumnType($"uuid");

        builder.Property(o => o.Name)
            .IsRequired();

        builder.Property(o => o.Users)
            .HasDefaultValue(new List<User.User>());

        builder.Property(o => o.LogoLink)
            .IsRequired();

        builder.HasMany(o => o.Users)
            .WithOne(u => u.Org);

        builder.HasData(new Organization
        {
            Id=Guid.NewGuid(),
            Name = "Test Organization",
            Users = new List<User.User>(),
            LogoLink = "https://robohash.org/test-org"
        });
    }
}