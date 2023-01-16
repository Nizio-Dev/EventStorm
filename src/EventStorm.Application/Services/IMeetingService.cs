using EventStorm.Application.Requests;
using EventStorm.Application.Responses;
using EventStorm.Domain.Entities;
using Sieve.Models;

namespace EventStorm.Application.Services
{
    public interface IMeetingService
    {
        Task<MeetingDto> AttendAsync(string meetingId, Attender attender);
        Task<MeetingDto> CreateAsync(CreateMeetingDto meetingDto, Attender owner);
        Task<ICollection<MeetingDto>> GetAllAsync(SieveModel sieveModel);
        Task<MeetingDto> GetAsync(string meetingId);
        Task<MeetingDto> UpdateAsync(string meetingId, EditMeetingDto meeting);
    }
}