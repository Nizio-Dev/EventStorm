using EventStorm.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventStorm.Infrastructure.Persistance.EntityBuilder
{
    public class AttendanceEntityBuilder : IEntityTypeConfiguration<Attendance>
    {
        public void Configure(EntityTypeBuilder<Attendance> builder)
        {
            builder
                .HasOne(a => a.Attender)
                .WithMany(a => a.Attendances)
                .IsRequired();

            builder
                .HasOne(a => a.Meeting)
                .WithMany(m => m.Attendances)
                .IsRequired();

            builder.Property(m => m.Id)
                .IsRequired();

            builder.Property(a => a.MeetingId)
                .IsRequired();

            builder.Property(a => a.AttenderId)
                .IsRequired();

            builder.Property(a => a.Status)
                .IsRequired();
        }
    }
}
