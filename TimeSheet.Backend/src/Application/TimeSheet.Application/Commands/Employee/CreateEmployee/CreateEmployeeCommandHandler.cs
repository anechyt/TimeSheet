using System.Threading.Tasks;
using TimeSheet.Application.Abstraction;
using TimeSheet.Application.Contracts.Proccesing;
using TimeSheet.Application.Mapper;

namespace TimeSheet.Application.Commands.Employee.CreateEmployee
{
    public class CreateEmployeeCommandHandler : ICommandHandler<CreateEmployeeCommand>
    {
        private readonly IEmployeeProccesing _employeeProccesing;
        public CreateEmployeeCommandHandler(IEmployeeProccesing employeeProccesing)
        {
            _employeeProccesing = employeeProccesing;
        }
        public async Task HandleAsync(CreateEmployeeCommand request)
        {
            var mapper = Mapping.CreateCommandEmployee(request);
            await _employeeProccesing.CreateEmployeeAsync(mapper);
        }
    }
}
