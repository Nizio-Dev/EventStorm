using EventStorm.Application.Responses;
using EventStorm.Domain.Entities;
using System.Security.Claims;

namespace EventStorm.Application.Services
{
	public interface IAttenderService
	{
		Task<AttenderDto> CreateAsync(ClaimsPrincipal user);

		Task<AttenderDto> GetAsync(string id);

		Task<Attender?> GetAsync(ClaimsPrincipal user);

		Task<AttenderDto> UpdateAsync(ClaimsPrincipal user);
	}
}