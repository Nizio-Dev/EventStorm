using AutoMapper;
using EventStorm.Application.Exceptions;
using EventStorm.Application.Requests;
using EventStorm.Application.Responses;
using EventStorm.Domain.Entities;
using EventStorm.Domain.Types;
using EventStorm.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace EventStorm.Application.Services
{
	public class MeetingService : IMeetingService
	{
		EventStormDbContext _dbContext;
		IMapper _mapper;
		
		public MeetingService(IMapper mapper, EventStormDbContext dbContext)
		{
			_mapper = mapper;
			_dbContext = dbContext;
		}

		public async Task<ICollection<MeetingDto>> GetAllAsync()
		{
			var meetings = await _dbContext.Meetings
				.AsNoTracking()
				.Include(m => m.Owner)
				.Include(m => m.Attendances)
				.Include(m => m.Categories)
				.ToListAsync();

			return _mapper.Map<ICollection<MeetingDto>>(meetings);
		}

		public async Task<MeetingDto> GetAsync(string id)
		{
			var meeting = await _dbContext.Meetings
				.AsNoTracking()
				.Include(m => m.Owner)
				.Include(m => m.Attendances)
				.Include(m => m.Categories) 
				.FirstOrDefaultAsync(m => m.Id == id);

			if (meeting == null)
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
				Attender = owner,
				Meeting = newMeeting,
				Status = Status.Present
			});

			await _dbContext.Meetings.AddAsync(newMeeting);
			await _dbContext.SaveChangesAsync();

			return _mapper.Map<MeetingDto>(newMeeting);
		}
	}
}
