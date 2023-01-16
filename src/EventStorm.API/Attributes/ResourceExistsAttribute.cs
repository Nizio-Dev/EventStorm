using EventStorm.Application.Exceptions;
using EventStorm.Domain.Entities;
using EventStorm.Infrastructure.Persistance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EventStorm.API.Attributes
{
    public class ResourceExistsAttribute : TypeFilterAttribute
    {
        public ResourceExistsAttribute(Type entityType) : base(typeof(ResourceExistsAttributeImpl)) 
        {
            Arguments = new object[] { entityType };
        }

        public class ResourceExistsAttributeImpl : ActionFilterAttribute
        {
            private readonly EventStormDbContext _dbContext;
            private readonly Type _entityType;

            public ResourceExistsAttributeImpl(EventStormDbContext dbContext, Type entityType)
            {
                _dbContext = dbContext;
                _entityType = entityType;
            }

            public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
            {
                var id = context.ActionArguments["id"] as string;

                var resource = await _dbContext.FindAsync(_entityType, id);

                if (resource == null)
                {
                    throw new ResourceNotFoundException($"{_entityType.Name} not found.");
                }

                await next();
            }
        }
    }
}
