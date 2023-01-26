using EventStorm.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventStorm.Application.Interface
{
    public interface IDbContext
    {
        public DbSet<Meeting> Meetings { get; set; }

        public DbSet<Attender> Attenders { get; set; }

        public DbSet<Attendance> Attendances { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}