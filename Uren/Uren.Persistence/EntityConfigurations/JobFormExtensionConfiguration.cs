using Finate.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finate.Persistence.EntityConfigurations;

public class JobFormExtensionConfiguration : IEntityTypeConfiguration<JobFormExtension>
{
    public void Configure(EntityTypeBuilder<JobFormExtension> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasMany(x => x.DescriptionParts)
            .WithOne(y => y.JobForm)
            .HasForeignKey(z => z.JobFormId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}