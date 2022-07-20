using TimeSheet.Application.Abstraction;

namespace TimeSheet.Application.Commands.Project.DeleteProject
{
    public class DeleteProjectCommand : ICommand
    {
        public int Id { get; set; }
    }
}
