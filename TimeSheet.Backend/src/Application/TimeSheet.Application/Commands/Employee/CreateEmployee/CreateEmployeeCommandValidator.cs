using FluentValidation;

namespace TimeSheet.Application.Commands.Employee.CreateEmployee
{
    public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
    {
        public CreateEmployeeCommandValidator()
        {
            RuleFor(x => x.Name).NotNull().MaximumLength(36);
            RuleFor(x => x.Sex).NotNull().MaximumLength(36);
            RuleFor(x => x.Birthday).NotNull();
        }
    }
}
