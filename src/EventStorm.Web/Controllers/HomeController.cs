using Auth0.AspNetCore.Authentication;
using EventStorm.Application.Requests;
using EventStorm.Application.Responses;
using EventStorm.Application.Services;
using EventStorm.Domain.Entities;
using EventStorm.Web.Helpers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EventStorm.Web.Controllers
{
    [Route("/[action]")]
    public class HomeController : Controller
    {
        private readonly IAttenderService _attenderService;

        public HomeController(IAttenderService attenderService)
        {
            _attenderService = attenderService;
        }

        [Route("/")]
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Attender");
            }

            return View();
        } 

        public async Task Login()
        {
            var authenticationProperties = new LoginAuthenticationPropertiesBuilder()
           .WithRedirectUri(Url.Action("LoginCallback", "Home"))
           .Build();

            await HttpContext.ChallengeAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
        }

        [Authorize]
        public async Task Logout()
        {
            var authenticationProperties = new LogoutAuthenticationPropertiesBuilder()
                .WithRedirectUri(Url.Action("Index", "Home"))
                .Build();

            await HttpContext.SignOutAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        [Authorize]
        public async Task<IActionResult> LoginCallback()
        {
            Attender attender;

            try
            {
				attender = await _attenderService.GetAttenderAsync(User.GetAuth0Id());

				if (hasUserChanged(attender))
				{
					await updateAttenderInfoAsync(attender);
				}
			}
            catch (Exception)
            {
			    await _attenderService.CreateAttenderAsync(new CreateAttenderDto
			    {
				    Auth0Id = User.GetAuth0Id(),
				    DisplayName = User.GetName(),
				    Email = User.GetEmail()
			    });
			}

           

            return RedirectToAction("Index", "Attender");
        }

        [NonAction]
        private bool hasUserChanged(Attender attender)
        {
            if (User.GetEmail() != attender.Email) return true;
            if (User.GetName() != attender.DisplayName) return true;

            return false;
        }

        [NonAction]
        private async Task updateAttenderInfoAsync(Attender attender)
        {
           
        }
    }
}