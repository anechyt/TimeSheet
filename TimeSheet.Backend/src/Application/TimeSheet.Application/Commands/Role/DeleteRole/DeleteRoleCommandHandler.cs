using System.Threading.Tasks;
using TimeSheet.Application.Abstraction;
using TimeSheet.Application.Contracts.Proccesing;
using TimeSheet.Application.Mapper;

namespace TimeSheet.Application.Commands.Role.DeleteRole
{
    public class DeleteRoleCommandHandler : ICommandHandler<DeleteRoleCommand>
    {
        private readonly IRoleProccesing _roleProccesing;
        public DeleteRoleCommandHandler(IRoleProccesing roleProccesing)
        {
            _roleProccesing = roleProccesing;
        }
        public async Task HandleAsync(DeleteRoleCommand command)
        {
            var mapper = Mapping.DeleteCommandRole(command);
            await _roleProccesing.DeleteRoleAsync(mapper);
        }
    }
}
