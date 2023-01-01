namespace EventStorm.Application.Responses
{
	public class MeetingAttendanceDto
	{
		public string Id { get; set; }

		public AttenderDto Attender { get; set; }

		public string Status { get; set; }
	}
}
