using System.Threading.Tasks;
using TimeSheet.Application.Abstraction;
using TimeSheet.Application.Contracts.Proccesing;
using TimeSheet.Application.Mapper;

namespace TimeSheet.Application.Commands.Employee.DeleteEmployee
{
    public class DeleteEmployeeCommandHandler : ICommandHandler<DeleteEmployeeCommand>
    {
        private readonly IEmployeeProccesing _employeeProccesing;
        public DeleteEmployeeCommandHandler(IEmployeeProccesing employeeProccesing)
        {
            _employeeProccesing = employeeProccesing;
        }
        public async Task HandleAsync(DeleteEmployeeCommand command)
        {
            var mapper = Mapping.DeleteCommandEmployee(command);
            await _employeeProccesing.DeleteEmployeeAsync(mapper);
        }
    }
}
