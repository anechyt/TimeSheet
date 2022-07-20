using System.Threading.Tasks;
using TimeSheet.Application.Abstraction;
using TimeSheet.Application.Contracts.View;
using TimeSheet.Application.Dto;

namespace TimeSheet.Application.Queries.Project.GetAll
{
    public class GetProjectsHandler : IQueryHandler<GetProjects, DataServiceMessage>
    {
        private readonly IProjectView _projectView;
        public GetProjectsHandler(IProjectView projectView)
        {
            _projectView = projectView;
        }
        public async Task<DataServiceMessage> HandleAsync(GetProjects query)
        {
            return await _projectView.GetAllProjects();
        }
    }
}
