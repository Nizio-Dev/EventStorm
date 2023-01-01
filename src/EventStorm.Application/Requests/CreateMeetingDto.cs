namespace EventStorm.Application.Requests
{
	public class CreateMeetingDto
	{
		public string Name { get; set; }

		public string Description { get; set; }

		public string Location { get; set; }

		public int MaxAttenders { get; set; }

		public ICollection<CreateCategoryDto> Categories { get; set; }

		public DateTime StartingTime { get; set; }

		public DateTime EndingTime { get; set; }
	}
}