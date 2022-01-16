using Brainstorm.Entities.AppVersion;
using Brainstorm.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace Brainstorm.Entities;

public class BrainstormContext : DbContext
{
    public BrainstormContext()
    {
    }

    public BrainstormContext(DbContextOptions opts) : base(opts)
    {
    }

    public DbSet<AppVersion.AppVersion> AppVersions { get; init; }
    public DbSet<User.User> Users { get; init; }
    public DbSet<Organization.Organization> Organizations { get; init; }
    
    public DbSet<Proposal.Proposal> Proposals { get; init; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new AppVersionConfig());
        builder.ApplyConfiguration(new UserConfig());
    }
}