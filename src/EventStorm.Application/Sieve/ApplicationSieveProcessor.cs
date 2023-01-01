using EventStorm.Application.Sieve.Configurations;
using Microsoft.Extensions.Options;
using Sieve.Models;
using Sieve.Services;

namespace EventStorm.Application.Sieve
{
	public class ApplicationSieveProcessor : SieveProcessor
	{
		public ApplicationSieveProcessor(IOptions<SieveOptions> options) : base(options) { }


		protected override SievePropertyMapper MapProperties(SievePropertyMapper mapper)
		{
			return mapper
				.ApplyConfiguration<SieveConfigurationForMeeting>();
		}
	}
}
