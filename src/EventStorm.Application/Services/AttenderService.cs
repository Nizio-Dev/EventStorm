using AutoMapper;
using AutoMapper.QueryableExtensions;
using EventStorm.Application.Exceptions;
using EventStorm.Application.Responses;
using EventStorm.Domain.Entities;
using EventStorm.Infrastructure.Persistance;
using EventStorm.Web.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace EventStorm.Application.Services
{

	public class AttenderService : IAttenderService
	{
		private readonly EventStormDbContext _dbContext;
		private readonly IMapper _mapper;

		public AttenderService(EventStormDbContext dbContext, IMapper mapper)
		{
			_dbContext = dbContext;
			_mapper = mapper;
		}

		public async Task<Attender?> GetAsync(ClaimsPrincipal user)
		{
			var attender = await _dbContext.Attenders
				.FirstOrDefaultAsync(a => a.AuthProviderId == user.GetAuthProviderId());

			return attender;
		}

		public async Task<AttenderDto> GetAsync(string attenderId)
		{
			var attender = await _dbContext.Attenders
				.ProjectTo<AttenderDto>(_mapper.ConfigurationProvider)
				.FirstOrDefaultAsync(a => a.Id == attenderId);

			if(attender == null)
			{
				throw new ResourceNotFoundException("Attender not found.");
			}

			return attender;
		}

		public async Task<AttenderDto> CreateAsync(ClaimsPrincipal user)
		{
			var newUser = _mapper.Map<Attender>(user);

			await _dbContext.Attenders.AddAsync(newUser);
			await _dbContext.SaveChangesAsync();

			return _mapper.Map<AttenderDto>(newUser);
		}

		public async Task<AttenderDto> UpdateAsync(ClaimsPrincipal user)
		{
			var attender = await GetAsync(user);

			attender.Email = user.GetEmail();
			attender.DisplayName = user.GetName();

			_dbContext.Attenders.Update(attender);
			await _dbContext.SaveChangesAsync();

			return _mapper.Map<AttenderDto>(attender);
		}
	}
}