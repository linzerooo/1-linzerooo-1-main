using Finate.Domain.Entities;
using Finate.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finate.Persistence.EntityConfigurations;

public class ExperienceConfiguration : IEntityTypeConfiguration<Experience>
{
    public void Configure(EntityTypeBuilder<Experience> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.PlaceName)
            .HasMaxLength(50);

        builder.Property(x => x.ProfessionName)
            .HasMaxLength(50);

        builder.Property(x => x.ExperienceType)
            .HasConversion(e => e.ToString(),
                s => (ExperienceType)Enum.Parse(typeof(ExperienceType), s));
    }
}