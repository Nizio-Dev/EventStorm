using EventStorm.API.Attributes;
using EventStorm.Application.Requests;
using EventStorm.Application.Services;
using EventStorm.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;

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
		public async Task<ActionResult> GetMeetings([FromQuery] SieveModel sieveModel)
		{
			var meetings = await _meetingService.GetAllAsync(sieveModel);

			return Ok(meetings);
		}

		[ResourceExists(typeof(Meeting))]
        [HttpGet]
		[Route("{id}")]
		public async Task<ActionResult> GetMeeting([FromRoute] string id)
		{
			var meeting = await _meetingService.GetAsync(id);

			return Ok(meeting);
		}

		[HttpPost]
		public async Task<ActionResult> CreateMeeting([FromBody] CreateMeetingDto meetingDto)
		{
			var owner = await _attenderService.GetAsync(User);

			var meeting = await _meetingService.CreateAsync(meetingDto, owner);

			return CreatedAtAction(nameof(GetMeeting), new { id = meeting.Id }, meeting);
		}

        [ResourceExists(typeof(Meeting))]
        [HttpPost]
		[Route("{id}/attend")]
		public async Task<ActionResult> AttendMeeting([FromRoute] string id)
		{
			var attender = await _attenderService.GetAsync(User);

			var requestedMeeting = await _meetingService.AttendAsync(id, attender);

			return Ok(requestedMeeting);
		}

        [ResourceExists(typeof(Meeting))]
        [HttpPatch]
		[Route("{id}")]
		public async Task<ActionResult> EditMeeting([FromRoute] string id, [FromBody] EditMeetingDto editMeetingDto)
		{
			var meeting = await _meetingService.UpdateAsync(id, editMeetingDto);

			return Ok(meeting);
		}

	}
}
