using EventStorm.Application.Extensions;
using EventStorm.Infrastructure.Extensions;
using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

// Add services to the container.

builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddAuthentication()
	.AddScheme<AuthenticationSchemeOptions, AlwaysAuthenticatedHandler>("AlwaysAuthenticated", options => { });

//builder.Services.AddAuthentication(options =>
//{
//	options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
//	options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//	options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//})
//.AddJwtBearer(options =>
//{
//	options.Authority = $"https://{builder.Configuration["Auth0:Domain"]}/";
//	options.Audience = builder.Configuration["Auth0:Audience"];
//	options.TokenValidationParameters = new TokenValidationParameters
//	{
//		NameClaimType = ClaimTypes.NameIdentifier
//	};
//});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
