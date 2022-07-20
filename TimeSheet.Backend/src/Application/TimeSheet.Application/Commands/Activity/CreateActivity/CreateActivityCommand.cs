using TimeSheet.Application.Abstraction;

namespace TimeSheet.Application.Commands.Activity.CreateActivity
{
    public class CreateActivityCommand : ICommand
    {
        public int ProjectId { get; set; }
        public int RoleId { get; set; }
        public int ActivityTypeId { get; set; }
        public int EmployeeId { get; set; }
    }
}
