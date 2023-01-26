using EventStorm.Application.Extensions;
using EventStorm.Infrastructure.Extensions;
using EventStorm.Infrastructure.Persistance;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication(builder.Configuration);
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

using var scope = app.Services.CreateScope();
scope.ServiceProvider.GetRequiredService<EventStormDbContext>()
	.Database.Migrate();

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();