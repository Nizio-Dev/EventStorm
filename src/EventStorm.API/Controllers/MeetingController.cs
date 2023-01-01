using EventStorm.Application.Requests;
using EventStorm.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventStorm.API.Controllers
{
	[Authorize]
	[Route("api/[controller]/")]
	[ApiController]
	public class MeetingController : ControllerBase
	{
		private readonly IMeetingService _meetingService;
		private readonly IAttenderService _attenderService;

		public MeetingController(IMeetingService meetingService, IAttenderService attenderService)
		{
			_meetingService = meetingService;
			_attenderService = attenderService;
		}

		[HttpGet]
		public async Task<IActionResult> GetMeetings()
		{
			var meetings = await _meetingService.GetAllAsync();

			return Ok(meetings);
		}

		[HttpGet]
		[Route("{id}")]
		public async Task<IActionResult> GetMeeting([FromRoute]string id)
		{
			var meeting = await _meetingService.GetAsync(id);

			return Ok(meeting);
		}

		[HttpPost]
		public async Task<IActionResult> CreateMeeting([FromBody]CreateMeetingDto meetingDto)
		{
			var owner = await _attenderService.GetAsync(User);

			var meeting = await _meetingService.CreateAsync(meetingDto, owner);

			return CreatedAtAction(nameof(GetMeeting), new { id = meeting.Id }, meeting);
		}
	}
}
