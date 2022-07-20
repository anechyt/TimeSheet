using FluentValidation;

namespace TimeSheet.Application.Commands.Activity.CreateActivity
{
    public class CreateActivityCommandValidator : AbstractValidator<CreateActivityCommand>
    {
        public CreateActivityCommandValidator()
        {
            RuleFor(x => x.ProjectId).NotNull();
            RuleFor(x => x.RoleId).NotNull();
            RuleFor(x => x.ActivityTypeId).NotNull();
            RuleFor(x => x.EmployeeId).NotNull();
        }
    }
}
