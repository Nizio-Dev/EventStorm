namespace EventStorm.Domain.Entities
{
    public class Meeting
    {
        public string Id { get; set; }

		public string OwnerId { get; set; }

		public Attender Owner { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public int MaxAttenders { get; set; }

		public ICollection<Attendance> Attendances { get; set; }

        public List<string> Categories { get; set; }

        public DateTime StartingTime { get; set; }

        public DateTime EndingTime { get; set; }

        public Meeting() 
        {
            Id = Guid.NewGuid().ToString();
            Attendances = new List<Attendance>();
        }
    }
}