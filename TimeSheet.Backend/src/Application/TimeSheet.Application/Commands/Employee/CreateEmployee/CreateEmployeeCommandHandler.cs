using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TimeSheet.Application.Contracts.Proccesing;
using TimeSheet.Application.Dto;
using TimeSheet.Application.Mapper;

namespace TimeSheet.Application.Commands.Employee.CreateEmployee
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, DataServiceMessage>
    {
        private readonly IEmployeeProccesing _employeeProccesing;
        public CreateEmployeeCommandHandler(IEmployeeProccesing employeeProccesing)
        {
            _employeeProccesing = employeeProccesing;
        }
        public Task<DataServiceMessage> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var mapper = Mapping.CreateCommandEmployee(request);
            var data = _employeeProccesing.CreateEmployeeAsync(mapper);

            return data;
        }
    }
}
