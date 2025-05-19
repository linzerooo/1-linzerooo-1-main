using Finate.Domain.Entities;
using Finate.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finate.Persistence.EntityConfigurations;

public class SocialNetworkConfiguration : IEntityTypeConfiguration<SocialNetwork>
{
    public void Configure(EntityTypeBuilder<SocialNetwork> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.SocialNetworkType)
            .HasConversion(e => e.ToString(),
                s => (SocialNetworkType)Enum.Parse(typeof(SocialNetwork), s));

        builder.Property(x => x.Link)
            .HasMaxLength(100);
    }
}