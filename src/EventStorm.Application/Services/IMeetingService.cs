using EventStorm.Application.Requests;
using EventStorm.Application.Responses;
using EventStorm.Domain.Entities;

namespace EventStorm.Application.Services
{
	public interface IMeetingService
	{
		Task<MeetingDto> CreateAsync(CreateMeetingDto meetingDto, Attender owner);
		Task<ICollection<MeetingDto>> GetAllAsync();
		Task<MeetingDto> GetAsync(string id);
	}
}