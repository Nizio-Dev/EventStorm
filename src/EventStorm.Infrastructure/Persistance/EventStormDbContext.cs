using EventStorm.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventStorm.Infrastructure.Persistance
{
    public class EventStormDbContext : DbContext
    {
        public EventStormDbContext(DbContextOptions<EventStormDbContext> options) : base(options) { }

        public DbSet<Attender> Attenders { get; set; }

        public DbSet<Attendance> Attendances { get; set; }

        public DbSet<Meeting> Meetings { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Attender>()
                .HasMany(a => a.Attendances)
                .WithOne(a => a.Attender);

            builder.Entity<Attender>()
                .HasMany(a => a.MeetingsOwnership)
                .WithOne(m => m.Owner);

            builder.Entity<Attendance>()
                .HasOne(a => a.Meeting)
                .WithMany(m => m.Attendances);

            builder.Entity<Meeting>()
                .HasMany(m => m.Categories);
        }
    }
}