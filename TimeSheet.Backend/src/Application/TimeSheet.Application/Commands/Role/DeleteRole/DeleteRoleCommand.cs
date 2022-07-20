using TimeSheet.Application.Abstraction;

namespace TimeSheet.Application.Commands.Role.DeleteRole
{
    public class DeleteRoleCommand : ICommand
    {
        public int Id { get; set; }
    }
}
