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
                .MaximumLength(100)
                .WithMessage("The length of meeting's name must be between 5 and 100 characters long.");

            RuleFor(x => x.Description)
                .MaximumLength(5000)
                .WithMessage("The length of meeting's description must be up to 5000 characters long.");

            RuleFor(x => x.Location)
                .NotNull();

            RuleFor(x => x.MaxAttenders)
                .NotNull()
                .InclusiveBetween(0, 1000);

            RuleFor(x => x.Categories)
                .NotNull()
                .Must(list => list.Count <= 10)
                .WithMessage("Only up to 10 of categories are allowed.");

            RuleFor(x => x.StartingTime)
                .NotNull();

            RuleFor(x => x)
                .Must(HaveProperTimeRange)
                .WithMessage("Ending date must come before starting date.");
        }

        private bool HaveProperTimeRange(CreateMeetingDto data)
        {
            return data.StartingTime < data.EndingTime;
        }
    }
}
