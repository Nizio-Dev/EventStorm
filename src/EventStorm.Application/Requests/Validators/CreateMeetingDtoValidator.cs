using FluentValidation;

namespace EventStorm.Application.Requests.Validators
{
    public class CreateMeetingDtoValidator : AbstractValidator<CreateMeetingDto>
    {
        public CreateMeetingDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(30);

            RuleFor(x => x.Description)
                .MaximumLength(255);

            RuleFor(x => x.MaxAttenders)
                .NotEmpty()
                .InclusiveBetween(0, 1000);

            RuleFor(x => x.Categories)
                .NotEmpty()
                .Must(list => list.Count <= 10)
                .WithMessage("Only 10 categories are allowed.");

            RuleFor(x => x.Location)
                .NotEmpty();

            RuleFor(x => x.StartingTime)
                .NotEmpty();
        }
    }
}
