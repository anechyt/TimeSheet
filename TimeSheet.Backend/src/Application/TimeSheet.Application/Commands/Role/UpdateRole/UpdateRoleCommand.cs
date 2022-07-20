using TimeSheet.Application.Abstraction;

namespace TimeSheet.Application.Commands.Role.UpdateRole
{
    public class UpdateRoleCommand : ICommand
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
