using Finate.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Finate.Application.Interfaces;

/// <summary>
/// Интерфейс БД контекста
/// </summary>
public interface IDbContext
{
    public DbSet<User> Users { get; set; }
    
    public DbSet<Form> Forms { get; set; }
    
    public DbSet<Skill> Skills { get; set; }

    public DbSet<SocialNetwork> SocialNetworks { get; set; }

    public DbSet<Tag> Tags { get; set; }

    public DbSet<UserLanguage> UserLanguages { get; set; }

    public DbSet<CandidateFormExtension> CandidateFormExtensions { get; set; }

    public DbSet<Experience> Experiences { get; set; }

    public DbSet<JobFormExtension> JobFormExtensions { get; set; }

    public DbSet<JobFormDescriptionPart> JobFormDescriptionParts { get; set; }

    public DbSet<ProductCard> ProductCard { get; set; }
    public DbSet<CartItem> CartItem { get; set; }

    Task<int> SaveChangesAsync(CancellationToken token);
}