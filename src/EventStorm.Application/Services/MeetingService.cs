using AutoMapper;
using AutoMapper.QueryableExtensions;
using EventStorm.Application.Exceptions;
using EventStorm.Application.Requests;
using EventStorm.Application.Responses;
using EventStorm.Domain.Entities;
using EventStorm.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;

namespace EventStorm.Application.Services
{
	public class MeetingService : IMeetingService
	{
		private readonly EventStormDbContext _dbContext;
		private readonly IMapper _mapper;
		private readonly ISieveProcessor _sieveProcessor;

		public MeetingService(IMapper mapper, EventStormDbContext dbContext, ISieveProcessor sieveProcessor)
		{
			_mapper = mapper;
			_dbContext = dbContext;
			_sieveProcessor = sieveProcessor;
		}

		public async Task<ICollection<MeetingDto>> GetAllAsync(SieveModel sieveModel)
		{
			var meetings = _dbContext.Meetings
				.AsNoTracking()
				.Include(m => m.Owner)
				.Include(m => m.Attendances)
				.Include(m => m.Categories);

			var result = await _sieveProcessor.Apply(sieveModel, meetings)
				.ProjectTo<MeetingDto>(_mapper.ConfigurationProvider)
				.ToListAsync();

			return result;
		}

		public async Task<MeetingDto> GetAsync(string meetingId)
		{
			var meeting = await _dbContext.Meetings
				.Include(m => m.Owner)
				.Include(m => m.Attendances)
				.Include(m => m.Categories)
				.FirstOrDefaultAsync(m => m.Id == meetingId);

			if(meeting == null)
			{
				throw new ResourceNotFoundException("Meeting not found.");
			}

			return _mapper.Map<MeetingDto>(meeting);
		}

		public async Task<MeetingDto> CreateAsync(CreateMeetingDto meetingDto, Attender owner)
		{
			var newMeeting = _mapper.Map<Meeting>(meetingDto);

			newMeeting.Owner = owner;

			newMeeting.Attendances.Add(new Attendance
			{
				Meeting = newMeeting,
				Attender = owner
			});

			await _dbContext.Meetings.AddAsync(newMeeting);
			await _dbContext.SaveChangesAsync();

			return _mapper.Map<MeetingDto>(newMeeting);
		}

		public async Task<MeetingDto> AttendAsync(string meetingId, Attender attender)
		{
			var requestedMeeting = await _dbContext.Meetings
				.Include(m => m.Attendances)
				.FirstOrDefaultAsync(m => m.Id == meetingId);

			if (requestedMeeting == null)
			{
				throw new ResourceNotFoundException("Meeting not found.");
			}

			if(attender.Attendances.FirstOrDefault(a => a.MeetingId == meetingId) != null)
			{
				throw new AttenderAlreadyInMeetingException("Attender already attends the meeting.");
			}

			if((requestedMeeting.Attendances.Count >= requestedMeeting.MaxAttenders) && requestedMeeting.MaxAttenders > 0)
			{
				throw new MaxUsersExcedeedException("The meeting is full");
			}

			requestedMeeting.Attendances.Add(new Attendance
			{
				Attender = attender,
				Meeting = requestedMeeting
			});

			await _dbContext.SaveChangesAsync();

			return _mapper.Map<MeetingDto>(requestedMeeting);
		}

		public async Task<MeetingDto> UpdateAsync(string meetingId, EditMeetingDto meeting)
		{
			var requestedMeeting = await _dbContext.Meetings
				.FirstOrDefaultAsync(m => m.Id == meetingId);

            if (requestedMeeting == null)
            {
                throw new ResourceNotFoundException("Meeting not found.");
            }
        }
	}
}
