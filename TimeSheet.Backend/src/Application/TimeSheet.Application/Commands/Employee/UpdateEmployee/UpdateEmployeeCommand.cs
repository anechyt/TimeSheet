using System;
using TimeSheet.Application.Abstraction;

namespace TimeSheet.Application.Commands.Employee.UpdateEmployee
{
    public class UpdateEmployeeCommand : ICommand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public DateTime Birthday { get; set; }
    }
}
