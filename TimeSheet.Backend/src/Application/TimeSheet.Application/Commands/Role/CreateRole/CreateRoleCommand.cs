using MediatR;
using TimeSheet.Application.Dto;

namespace TimeSheet.Application.Commands.Role.CreateRole
{
    public class CreateRoleCommand : IRequest<DataServiceMessage>
    {
        public string Name { get; set; }
    }
}
