using EventStorm.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventStorm.Infrastructure.Persistance.EntityBuilder
{
    public class MeetingEntityBuilder : IEntityTypeConfiguration<Meeting>
    {
        public void Configure(EntityTypeBuilder<Meeting> builder)
        {
            builder.Property(m => m.Id)
                .IsRequired();

            builder.Property(m => m.Owner)
                .IsRequired();

            builder.Property(m => m.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(m => m.Description)
                .HasMaxLength(5000);

            builder.Property(m => m.Location)
                .HasMaxLength(80)
                .IsRequired();

            builder.Property(m => m.MaxAttenders)
                .IsRequired();

            builder.Property(m => m.Categories)
                .IsRequired();

            builder.Property(m => m.StartingTime)
                .IsRequired();

            builder.Property(m => m.EndingTime)
                .IsRequired();
        }
    }
}
