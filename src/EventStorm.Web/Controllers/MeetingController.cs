using EventStorm.Application.Requests;
using EventStorm.Application.Services;
using EventStorm.Domain.Entities;
using EventStorm.Web.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventStorm.Web.Controllers
{
    [Authorize]
    [Route("[controller]/")]
    public class MeetingController : Controller
    {
        private readonly IMeetingService _meetingService;
        private readonly IAttenderService _attenderService;
        private readonly IAttendanceService _attendanceService;

		public MeetingController(IMeetingService meetingService, IAttenderService attenderService, 
            IAttendanceService attendanceService)
		{
			_meetingService = meetingService;
			_attenderService = attenderService;
			_attendanceService = attendanceService;
		}

		[Route("")]
		public async Task<IActionResult> Index()
		{
            var meetings = await _meetingService.GetMeetingsAsync();

			ViewBag.Meetings = meetings;

			return View();
		}

		[Route("{meetingId}")]
        public async Task<IActionResult> Meeting([FromRoute]string meetingId)
        {
            var attender = await _attenderService.GetAttenderAsync(User.GetAuth0Id());

            var meeting = await _meetingService.GetMeetingAsync(meetingId);

            var attendance = await _attendanceService.GetAttendanceAsync(attender, meetingId);

            ViewBag.Attendance = attendance;
            ViewBag.Meeting = meeting;

			return View();
        }

		[HttpGet]
        [Route("createmeeting")]
        public IActionResult CreateMeeting() => View();



        [HttpPost]
        [Route("createmeeting")]
        public async Task<IActionResult> CreateMeeting([Bind]CreateMeetingDto meeting)
        {
            var owner = await _attenderService.GetAttenderAsync(User.GetAuth0Id());

            await _meetingService.CreateMeetingAsync(meeting, owner);
            
            return View();
        }
    }
}
