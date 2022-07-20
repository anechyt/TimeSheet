using MediatR;
using System;
using TimeSheet.Application.Dto;

namespace TimeSheet.Application.Commands.Employee.CreateEmployee
{
    public class CreateEmployeeCommand : IRequest<DataServiceMessage>
    {
        public string Name { get; set; }
        public string Sex { get; set; }
        public DateTime Birthday { get; set; }
    }
}
