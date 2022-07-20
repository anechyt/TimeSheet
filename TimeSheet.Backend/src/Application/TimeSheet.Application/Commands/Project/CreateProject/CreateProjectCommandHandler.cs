using System.Threading.Tasks;
using TimeSheet.Application.Abstraction;
using TimeSheet.Application.Contracts.Proccesing;
using TimeSheet.Application.Mapper;

namespace TimeSheet.Application.Commands.Project.CreateProject
{
    public class CreateProjectCommandHandler : ICommandHandler<CreateProjectCommand>
    {
        private readonly IProjectProccesing _projectProccesing;
        public CreateProjectCommandHandler(IProjectProccesing projectProccesing)
        {
            _projectProccesing = projectProccesing;
        }
        public async Task HandleAsync(CreateProjectCommand request)
        {
            var mapper = Mapping.CreateCommandProject(request);
            await _projectProccesing.CreateProjectAsync(mapper);
        }
    }
}
