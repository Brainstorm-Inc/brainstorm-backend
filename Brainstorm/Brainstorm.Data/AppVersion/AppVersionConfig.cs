using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Brainstorm.Entities.AppVersion
{
    public class AppVersionConfig : IEntityTypeConfiguration<AppVersion>
    {
        public void Configure(EntityTypeBuilder<AppVersion> builder)
        {
            builder.Property(v => v.Id).HasColumnType($"uuid");
            
            builder.Property(v => v.MajorVersion).IsRequired();
            builder.Property(v => v.MinorVersion).HasDefaultValue(0);
            builder.HasData(new AppVersion
                {
                    // TODO set Id to be a proper uuid
                    Id = Guid.NewGuid(),
                    MajorVersion = 0,
                    MinorVersion = 1
                }
            );
        }
    }
}