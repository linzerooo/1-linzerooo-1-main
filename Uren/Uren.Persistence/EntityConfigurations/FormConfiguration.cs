using Finate.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finate.Persistence.EntityConfigurations;

public class FormConfiguration : IEntityTypeConfiguration<Form>
{
    public void Configure(EntityTypeBuilder<Form> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.HasIndex(x => x.IsActive);
        builder.HasIndex(x => x.ProfessionName);
        builder.HasIndex(x => x.Rating);

        builder.HasMany(x => x.Skills)
            .WithMany(y => y.Forms);

        builder.HasMany(x => x.Tags)
            .WithMany(y => y.Forms);

        builder.HasMany(x => x.Languages)
            .WithMany(y => y.Forms);
        
        builder.Property(x => x.ProfessionName)
            .HasMaxLength(40);
    }
}