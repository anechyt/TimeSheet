using FluentValidation;

namespace TimeSheet.Application.Commands.Role.CreateRole
{
    public class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
    {
        public CreateRoleCommandValidator()
        {
            RuleFor(x => x.Name).NotNull().MaximumLength(36);
        }
    }
}
