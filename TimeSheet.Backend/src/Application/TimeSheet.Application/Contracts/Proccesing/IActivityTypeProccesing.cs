using System.Threading.Tasks;
using TimeSheet.Application.Dto;

namespace TimeSheet.Application.Contracts.Proccesing
{
    public interface IActivityTypeProccesing
    {
        Task<DataServiceMessage> CreateActivityTypeAsync(CreateActivityTypeDto createActivityTypeDto);
        Task<DataServiceMessage> UpdateActivityTypeAsync(UpdateActivityTypeDto updateActivityTypeDto);
        Task<DataServiceMessage> DeleteActivityTypeAsync(DeleteActivityTypeDto deleteActivityTypeDto);
    }
}
