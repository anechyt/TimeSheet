using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TimeSheet.Application.Contracts.Proccesing;
using TimeSheet.Application.Dto;
using TimeSheet.Application.Mapper;

namespace TimeSheet.Application.Commands.Project.CreateProject
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, DataServiceMessage>
    {
        private readonly IProjectProccesing _projectProccesing;
        public CreateProjectCommandHandler(IProjectProccesing projectProccesing)
        {
            _projectProccesing = projectProccesing;
        }
        public Task<DataServiceMessage> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var mapper = Mapping.CreateCommandProject(request);
            var data = _projectProccesing.CreateProjectAsync(mapper);

            return data;
        }
    }
}
