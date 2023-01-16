using EventStorm.API.Attributes;
using EventStorm.Application.Services;
using EventStorm.Domain.Entities;
using EventStorm.Web.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventStorm.API.Controllers
{
	[Authorize]
	[Route("api/[controller]/")]
	[ApiController]
	public class AttenderController : ControllerBase
	{
		private readonly IAttenderService _attenderService;

		public AttenderController(IAttenderService attenderService)
		{
			_attenderService = attenderService;
		}

		[Route("synchronize")]
		[HttpPost]
		public async Task<ActionResult> Synchronize()
		{
			var attender = await _attenderService.GetAsync(User);

			if(attender == null)
			{
				return await createAttenderAsync();
			}

			if (compareUserClaims(attender))
			{
				return await updateAttenderAsync();
			}

			return Ok(attender);
		}

        [ResourceExists(typeof(Attender))]
        [Route("{id}")]
		[HttpGet]
		public async Task<ActionResult> GetAttender([FromRoute] string id)
		{
			var attender = await _attenderService.GetAsync(id);

			return Ok(attender);
		}

		[NonAction]
		private async Task<ActionResult> createAttenderAsync()
		{
			var newAttender = await _attenderService.CreateAsync(User);

			return CreatedAtAction(nameof(GetAttender), new { id = newAttender.Id }, newAttender);
		}

		[NonAction]
		private bool compareUserClaims(Attender attender)
		{
			return User.GetEmail() != attender.Email || User.GetName() != attender.DisplayName;
		}

		[NonAction]
		private async Task<ActionResult> updateAttenderAsync()
		{
			var updatedAttender = await _attenderService.UpdateAsync(User);

			return Ok(updatedAttender);
		}
	}
}
