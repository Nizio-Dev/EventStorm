using EventStorm.Domain.Types;

namespace EventStorm.Domain.Entities
{
    public class Attendance
    {
        public string Id { get; set; }

        public Meeting Meeting { get; set; }

        public Attender Attender { get; set; }

        public string Status { get; set; }

        public Attendance()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}