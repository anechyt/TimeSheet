using MediatR;
using TimeSheet.Application.Abstraction;
using TimeSheet.Application.Dto;

namespace TimeSheet.Application.Commands.Role.CreateRole
{
    public class CreateRoleCommand : ICommand
    {
        public string Name { get; set; }
    }
}
