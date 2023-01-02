using EventStorm.Application.Requests;
using EventStorm.Application.Services;
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
		public async Task<ActionResult> GetMeetings([FromQuery]SieveModel sieveModel)
		{
			var meetings = await _meetingService.GetAllAsync(sieveModel);

			return Ok(meetings);
		}

		[HttpGet]
		[Route("{meetingId}")]
		public async Task<ActionResult> GetMeeting([FromRoute]string meetingId)
		{
			var meeting = await _meetingService.GetAsync(meetingId);

			return Ok(meeting);
		}

		[HttpPost]
		public async Task<ActionResult> CreateMeeting([FromBody]CreateMeetingDto meetingDto)
		{
			var owner = await _attenderService.GetAsync(User);

			var meeting = await _meetingService.CreateAsync(meetingDto, owner);

			return CreatedAtAction(nameof(GetMeeting), new { meetingId = meeting.Id }, meeting);
		}

		[HttpPost]
		[Route("{meetingId}/attend")]
		public async Task<ActionResult> AttendMeeting([FromRoute]string meetingId)
		{
			var attender = await _attenderService.GetAsync(User);

			var requestedMeeting = await _meetingService.AttendAsync(meetingId, attender);

			return Ok(requestedMeeting);
		}
	}
}
