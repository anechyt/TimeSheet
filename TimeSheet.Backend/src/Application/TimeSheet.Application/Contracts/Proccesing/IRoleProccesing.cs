using System.Threading.Tasks;
using TimeSheet.Application.Dto;

namespace TimeSheet.Application.Contracts.Proccesing
{
    public interface IRoleProccesing
    {
        Task<DataServiceMessage> CreateRoleAsync(CreateRoleDto createRoleDto);
        Task<DataServiceMessage> UpdateRoleAsync(UpdateRoleDto updateRoleDto);
        Task<DataServiceMessage> DeleteRoleAsync(DeleteRoleDto deleteRoleDto);
    }
}
