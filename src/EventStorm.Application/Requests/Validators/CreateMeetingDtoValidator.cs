using FluentValidation;

namespace EventStorm.Application.Requests.Validators
{
    public class CreateMeetingDtoValidator : AbstractValidator<CreateMeetingDto>
    {
        public CreateMeetingDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .MinimumLength(5)
                .MaximumLength(30);

            RuleFor(x => x.Description)
                .MaximumLength(255);

            RuleFor(x => x.MaxAttenders)
                .NotNull()
                .InclusiveBetween(0, 1000);

            RuleFor(x => x.Categories)
                .NotNull()
                .Must(list => list.Count <= 10)
                .WithMessage("Only up to 10 of categories are allowed.");

            RuleFor(x => x.Location)
                .NotNull();

            RuleFor(x => x.StartingTime)
                .NotNull();
        }
    }
}
