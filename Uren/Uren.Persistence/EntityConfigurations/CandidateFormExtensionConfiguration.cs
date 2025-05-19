using Finate.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finate.Persistence.EntityConfigurations;

public class CandidateFormExtensionConfiguration : IEntityTypeConfiguration<CandidateFormExtension>
{
    public void Configure(EntityTypeBuilder<CandidateFormExtension> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.HasMany(x => x.Experiences)
            .WithOne(y => y.CandidateFormExtension)
            .HasForeignKey(z => z.CandidateFormId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}