using System.Threading.Tasks;
using TimeSheet.Application.Abstraction;
using TimeSheet.Application.Contracts.Proccesing;
using TimeSheet.Application.Mapper;

namespace TimeSheet.Application.Commands.Employee.UpdateEmployee
{
    public class UpdateEmployeeCommandHandler : ICommandHandler<UpdateEmployeeCommand>
    {
        private readonly IEmployeeProccesing _employeeProccesing;
        public UpdateEmployeeCommandHandler(IEmployeeProccesing employeeProccesing)
        {
            _employeeProccesing = employeeProccesing;
        }
        public async Task HandleAsync(UpdateEmployeeCommand command)
        {
            var mapper = Mapping.UpdateCommandEmployee(command);
            await _employeeProccesing.UpdateEmployeeAsync(mapper);
        }
    }
}
