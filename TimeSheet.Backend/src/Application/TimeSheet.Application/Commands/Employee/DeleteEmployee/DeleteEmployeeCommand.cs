using TimeSheet.Application.Abstraction;

namespace TimeSheet.Application.Commands.Employee.DeleteEmployee
{
    public class DeleteEmployeeCommand : ICommand
    {
        public int Id { get; set; }
    }
}
