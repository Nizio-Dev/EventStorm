using EventStorm.Application.Interface;
using EventStorm.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EventStorm.Infrastructure.Persistance
{
    public class EventStormDbContext : DbContext, IDbContext
    {
        public EventStormDbContext(DbContextOptions<EventStormDbContext> options) : base(options) { }

        public DbSet<Attender> Attenders { get; set; }

        public DbSet<Attendance> Attendances { get; set; }

        public DbSet<Meeting> Meetings { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}