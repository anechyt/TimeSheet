using System.Threading.Tasks;
using TimeSheet.Application.Dto;

namespace TimeSheet.Application.Contracts.Proccesing
{
    public interface IEmployeeProccesing
    {
        Task<DataServiceMessage> CreateEmployeeAsync(CreateEmployeeDto createEmployeeDto);
        Task<DataServiceMessage> UpdateEmployeeAsync(UpdateEmployeeDto updateEmployeeDto);
        Task<DataServiceMessage> DeleteEmployeeAsync(DeleteEmployeeDto deleteEmployeeDto);
    }
}
