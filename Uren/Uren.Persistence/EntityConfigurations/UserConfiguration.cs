using Finate.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finate.Persistence.EntityConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .HasMany(x => x.SocialNetworks)
            .WithOne(y => y.User)
            .HasForeignKey(z => z.UserId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}