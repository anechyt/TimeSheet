using System.Threading.Tasks;
using TimeSheet.Application.Dto;

namespace TimeSheet.Application.Contracts.Proccesing
{
    public interface IProjectProccesing
    {
        Task<DataServiceMessage> CreateProjectAsync(CreateProjectDto createProjectDto);
        Task<DataServiceMessage> UpdateProjectAsync(UpdateProjectDto updateProjectDto);
        Task<DataServiceMessage> DeleteProjectAsync(DeleteProjectDto deleteProjectDto);
    }
}
