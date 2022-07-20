using System.Threading.Tasks;
using TimeSheet.Application.Dto;

namespace TimeSheet.Application.Contracts.View
{
    public interface IProjectView
    {
        Task<DataServiceMessage> GetAllProjects();
        Task<DataServiceMessage> GetProjectById(int id);
    }
}
