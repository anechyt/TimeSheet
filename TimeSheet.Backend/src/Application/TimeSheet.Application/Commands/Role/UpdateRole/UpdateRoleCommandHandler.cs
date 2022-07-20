using System.Threading.Tasks;
using TimeSheet.Application.Abstraction;
using TimeSheet.Application.Contracts.Proccesing;
using TimeSheet.Application.Mapper;

namespace TimeSheet.Application.Commands.Role.UpdateRole
{
    public class UpdateRoleCommandHandler : ICommandHandler<UpdateRoleCommand>
    {
        private readonly IRoleProccesing _roleProccesing;
        public UpdateRoleCommandHandler(IRoleProccesing roleProccesing)
        {
            _roleProccesing = roleProccesing;
        }
        public async Task HandleAsync(UpdateRoleCommand command)
        {
            var mapper = Mapping.UpdateCommandRole(command);
            await _roleProccesing.UpdateRoleAsync(mapper);
        }
    }
}
