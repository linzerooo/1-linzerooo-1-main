using Finate.Application.Interfaces;
using Finate.Domain.Entities;
using Finate.Persistence.EntityConfigurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Finate.Persistence;

public class DbContext : IdentityDbContext<User, Role, Guid>, IDbContext
{
    public DbSet<Form> Forms { get; set; } = default!;
    
    public DbSet<Skill> Skills { get; set; } = default!;

    public DbSet<SocialNetwork> SocialNetworks { get; set; } = default!;

    public DbSet<Tag> Tags { get; set; } = default!;

    public DbSet<UserLanguage> UserLanguages { get; set; } = default!;

    public DbSet<CandidateFormExtension> CandidateFormExtensions { get; set; } = default!;

    public DbSet<Experience> Experiences { get; set; } = default!;

    public DbSet<JobFormExtension> JobFormExtensions { get; set; } = default!;

    public DbSet<JobFormDescriptionPart> JobFormDescriptionParts { get; set; } = default!;
    public DbSet<ProductCard> ProductCard { get; set; }
    public DbSet<CartItem> CartItem { get; set; }

    public DbContext()
    {
    }
    
    public DbContext(DbContextOptions<DbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new FormConfiguration());
        builder.ApplyConfiguration(new CandidateFormExtensionConfiguration());
        builder.ApplyConfiguration(new ExperienceConfiguration());
        builder.ApplyConfiguration(new JobFormExtensionConfiguration());
        builder.ApplyConfiguration(new JobFormDescriptionPartConfiguration());
        builder.ApplyConfiguration(new RoleConfiguration());
        builder.ApplyConfiguration(new SkillConfiguration());
        builder.ApplyConfiguration(new SocialNetworkConfiguration());
        builder.ApplyConfiguration(new TagConfiguration());
        builder.ApplyConfiguration(new UserConfiguration());
        builder.ApplyConfiguration(new UserLanguageConfiguration());
        base.OnModelCreating(builder);
    }
}