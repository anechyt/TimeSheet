using System;
using TimeSheet.Application.Abstraction;

namespace TimeSheet.Application.Commands.Employee.CreateEmployee
{
    public class CreateEmployeeCommand : ICommand
    {
        public string Name { get; set; }
        public string Sex { get; set; }
        public DateTime Birthday { get; set; }
    }
}
