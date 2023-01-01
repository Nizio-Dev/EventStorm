using System.Security.Claims;

namespace EventStorm.Web.Helpers
{
	public static class CurrentUserHelper
	{
		public static string GetAuthProviderId(this ClaimsPrincipal user) =>
			user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;

		public static string GetName(this ClaimsPrincipal user) =>
			user.Identity.Name;

		public static string GetEmail(this ClaimsPrincipal user) =>
			user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;
	}
}
