using AutoMapper;
using AutoMapper.QueryableExtensions;
using EventStorm.Application.Exceptions;
using EventStorm.Application.Requests;
using EventStorm.Application.Responses;
using EventStorm.Domain.Entities;
using EventStorm.Domain.Types;
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

		public async Task<MeetingDto> GetAsync(string id)
		{
			var meeting = await _dbContext.Meetings
				.AsNoTracking()
				.Include(m => m.Owner)
				.Include(m => m.Attendances)
				.Include(m => m.Categories)
				.FirstOrDefaultAsync(m => m.Id == id);

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
	}
}
