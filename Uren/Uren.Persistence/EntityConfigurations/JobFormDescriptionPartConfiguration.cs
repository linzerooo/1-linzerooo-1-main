using Finate.Domain.Entities;
using Finate.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finate.Persistence.EntityConfigurations;

public class JobFormDescriptionPartConfiguration : IEntityTypeConfiguration<JobFormDescriptionPart>
{
    public void Configure(EntityTypeBuilder<JobFormDescriptionPart> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.DescriptionPartType)
            .HasConversion(e => e.ToString(),
                s => (DescriptionPartType)Enum.Parse(typeof(DescriptionPartType), s));
    }
}