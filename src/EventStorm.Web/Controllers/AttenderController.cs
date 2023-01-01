using EventStorm.Application.Services;
using EventStorm.Web.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventStorm.Web.Controllers
{
    [Authorize]
    [Route("[controller]/")]
    public class AttenderController : Controller
    {
        IAttenderService _attenderService;
        IAttendanceService _attendanceService;

		public AttenderController(IAttenderService attenderService, IAttendanceService attendanceService)
		{
			_attenderService = attenderService;
			_attendanceService = attendanceService;
		}

        [Route("")]
        public async Task<IActionResult> Index()
        {
            var attender = await _attenderService.GetAttenderAsync(User.GetAuth0Id());

            ViewBag.Attendances = await _attendanceService.GetAttendancesAsync(attender);

            return View();
        }
    }
}
