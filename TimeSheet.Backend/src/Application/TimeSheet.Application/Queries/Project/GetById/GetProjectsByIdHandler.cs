using System.Threading.Tasks;
using TimeSheet.Application.Abstraction;
using TimeSheet.Application.Contracts.View;
using TimeSheet.Application.Dto;

namespace TimeSheet.Application.Queries.Project.GetById
{
    public class GetProjectsByIdHandler : IQueryHandler<GetProjectsById, DataServiceMessage>
    {
        private readonly IProjectView _projectView;
        public GetProjectsByIdHandler(IProjectView projectView)
        {
            _projectView = projectView;
        }
        public async Task<DataServiceMessage> HandleAsync(GetProjectsById query)
        {
            return await _projectView.GetProjectById(query.Id);
        }
    }
}
