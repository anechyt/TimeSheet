using System.Threading.Tasks;
using TimeSheet.Application.Dto;

namespace TimeSheet.Application.Contracts.Proccesing
{
    public interface IActivityProccesing
    {
        Task<DataServiceMessage> CreateActivityAsync(CreateActivityDto createActivityDto);
        Task<DataServiceMessage> UpdateActivityAsync(UpdateActivityDto updateActivityDto);
        Task<DataServiceMessage> DeleteActivityAsync(DeleteActivityDto deleteActivityDto);
    }
}
