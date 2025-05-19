using Finate.Domain.Entities;
using Finate.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finate.Persistence.EntityConfigurations;

public class SkillConfiguration : IEntityTypeConfiguration<Skill>
{
    public void Configure(EntityTypeBuilder<Skill> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.SkillType)
            .HasConversion(e => e.ToString(),
                s => (SkillType)Enum.Parse(typeof(SkillType), s));

        builder.Property(x => x.SkillName)
            .HasMaxLength(25);
    }
}