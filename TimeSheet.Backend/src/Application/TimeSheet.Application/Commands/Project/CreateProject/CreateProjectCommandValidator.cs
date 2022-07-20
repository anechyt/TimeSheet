using FluentValidation;

namespace TimeSheet.Application.Commands.Project.CreateProject
{
    public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
    {
        public CreateProjectCommandValidator()
        {
            RuleFor(c => c.Name).NotNull().MaximumLength(36);
            RuleFor(c => c.DateStart).NotNull();
            RuleFor(c => c.DateEnd).NotNull();
        }
    }
}
