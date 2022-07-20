using FluentValidation;

namespace TimeSheet.Application.Commands.ActivityType.CreateActivityType
{
    public class CreateActivityTypeCommandValidator : AbstractValidator<CreateActivityTypeCommand>
    {
        public CreateActivityTypeCommandValidator()
        {
            RuleFor(x => x.Name).NotNull().MaximumLength(36);
        }
    }
}
