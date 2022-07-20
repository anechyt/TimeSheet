using System.Threading.Tasks;
using TimeSheet.Application.Abstraction;
using TimeSheet.Application.Contracts.Proccesing;
using TimeSheet.Application.Mapper;

namespace TimeSheet.Application.Commands.Project.UpdateProject
{
    public class UpdateProjectCommandHandler : ICommandHandler<UpdateProjectCommand>
    {
        private readonly IProjectProccesing _projectProccesing;
        public UpdateProjectCommandHandler(IProjectProccesing projectProccesing)
        {
            _projectProccesing = projectProccesing;
        }
        public async Task HandleAsync(UpdateProjectCommand command)
        {
            var mapper = Mapping.UpdateCommandProject(command);
            await _projectProccesing.UpdateProjectAsync(mapper);
        }
    }
}
