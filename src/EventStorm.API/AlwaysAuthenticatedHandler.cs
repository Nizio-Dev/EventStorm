using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text.Encodings.Web;

public class AlwaysAuthenticatedHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
	public AlwaysAuthenticatedHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
	{
	}

	protected override Task<AuthenticateResult> HandleAuthenticateAsync()
	{
		var identity = new ClaimsIdentity(new[]
		{
			new Claim(ClaimTypes.NameIdentifier, "773ef2e2-b69e-41ce-920c-92ba612c99d9"),
			new Claim(ClaimTypes.Name, "TestUser"),
			new Claim(ClaimTypes.Email, "Test@test.com"),
		}, "AlwaysAuthenticated");
		var principal = new ClaimsPrincipal(identity);
		var ticket = new AuthenticationTicket(principal, "AlwaysAuthenticated");

		return Task.FromResult(AuthenticateResult.Success(ticket));
	}
}