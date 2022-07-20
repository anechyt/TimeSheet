using TimeSheet.Application.Abstraction;

namespace TimeSheet.Application.Commands.Activity.UpdateActivity
{
    public class UpdateActivityCommand : ICommand
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int RoleId { get; set; }
        public int ActivityTypeId { get; set; }
        public int EmployeeId { get; set; }
    }
}
