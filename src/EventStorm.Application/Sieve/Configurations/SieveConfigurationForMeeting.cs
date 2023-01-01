using EventStorm.Domain.Entities;
using Sieve.Services;

namespace EventStorm.Application.Sieve.Configurations
{
	public class SieveConfigurationForMeeting : ISieveConfiguration
	{
		public void Configure(SievePropertyMapper mapper)
		{
			mapper.Property<Meeting>(m => m.Name)
				.CanFilter()
				.CanSort();

			mapper.Property<Meeting>(m => m.Description)
				.CanFilter();

			mapper.Property<Meeting>(m => m.Location) 
				.CanFilter()
				.CanSort();

			mapper.Property<Meeting>(m => m.MaxAttenders)
				.CanSort();

			mapper.Property<Meeting>(m => m.Categories)
				.CanFilter()
				.CanSort();

			mapper.Property<Meeting>(m => m.StartingTime)
				.CanFilter()
				.CanSort();

			mapper.Property<Meeting>(m => m.EndingTime)
				.CanFilter()
				.CanSort();
		}
	}
}
