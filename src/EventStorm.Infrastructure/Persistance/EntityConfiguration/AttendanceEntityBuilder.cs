using EventStorm.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventStorm.Infrastructure.Persistance.EntityBuilder
{
    public class AttendanceEntityBuilder : IEntityTypeConfiguration<Attendance>
    {
        public void Configure(EntityTypeBuilder<Attendance> builder)
        {
            builder.Property(m => m.Id)
                .IsRequired();

            builder.Property(a => a.Meeting)
                .IsRequired();

            builder.Property(a => a.Attender)
                .IsRequired();

            builder.Property(a => a.Status)
                .IsRequired();
        }
    }
}
