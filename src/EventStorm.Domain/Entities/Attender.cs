namespace EventStorm.Domain.Entities
{
    public class Attender
    {
        public string Id { get; set; }

        public string AuthProviderId { get; set; }

        public string DisplayName { get; set; }

        public string Email { get; set; }   

        public ICollection<Attendance> Attendances { get; set; }

        public ICollection<Meeting> MeetingsOwnership { get; set; }

		public Attender()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}