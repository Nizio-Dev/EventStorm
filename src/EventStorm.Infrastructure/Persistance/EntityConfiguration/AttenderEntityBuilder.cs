using EventStorm.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventStorm.Infrastructure.Persistance.EntityBuilder
{
    public class AttenderEntityBuilder : IEntityTypeConfiguration<Attender>
    {
        public void Configure(EntityTypeBuilder<Attender> builder)
        {
            builder
                .HasMany(a => a.MeetingsOwnership)
                .WithOne(m => m.Owner);

            builder
                .HasMany(a => a.Attendances)
                .WithOne(a => a.Attender);

            builder.Property(a => a.Id)
                .IsRequired();

            builder.Property(a => a.AuthProviderId)
                .IsRequired();

            builder.Property(a => a.DisplayName)
                .IsRequired();

            builder.Property(a => a.Email)
                .IsRequired();
        }
    }
}
