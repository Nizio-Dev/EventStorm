using EventStorm.Domain.Entities;

namespace EventStorm.Application.Responses
{
	public class MeetingDto
	{
		public string Id { get; set; }

		public AttenderDto Owner { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public string Location { get; set; }

		public int MaxAttenders { get; set; }

		public ICollection<MeetingAttendanceDto> Attendances { get; set; }

		public ICollection<string> Categories { get; set; }

		public DateTime StartingTime { get; set; }

		public DateTime EndingTime { get; set; }
	}
}