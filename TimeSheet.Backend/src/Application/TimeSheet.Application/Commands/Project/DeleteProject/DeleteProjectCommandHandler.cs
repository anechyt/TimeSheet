using System.Threading.Tasks;
using TimeSheet.Application.Abstraction;
using TimeSheet.Application.Contracts.Proccesing;
using TimeSheet.Application.Mapper;

namespace TimeSheet.Application.Commands.Project.DeleteProject
{
    public class DeleteProjectCommandHandler : ICommandHandler<DeleteProjectCommand>
    {
        private readonly IProjectProccesing _projectProccesing;
        public DeleteProjectCommandHandler(IProjectProccesing projectProccesing)
        {
            _projectProccesing = projectProccesing;
        }
        public async Task HandleAsync(DeleteProjectCommand command)
        {
            var mapper = Mapping.DeleteCommandProject(command);
            await _projectProccesing.DeleteProjectAsync(mapper);
        }
    }
}
