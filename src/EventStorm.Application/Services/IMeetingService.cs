using EventStorm.Application.Requests;
using EventStorm.Application.Responses;
using EventStorm.Domain.Entities;
using Sieve.Models;

namespace EventStorm.Application.Services
{
	public interface IMeetingService
	{
		Task<MeetingDto> CreateAsync(CreateMeetingDto meetingDto, Attender owner);
		Task<ICollection<MeetingDto>> GetAllAsync(SieveModel sieveModel);
		Task<MeetingDto> GetAsync(string id);
	}
}