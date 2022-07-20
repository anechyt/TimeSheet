using System.Threading.Tasks;
using TimeSheet.Application.Abstraction;
using TimeSheet.Application.Contracts.Proccesing;
using TimeSheet.Application.Mapper;

namespace TimeSheet.Application.Commands.Role.CreateRole
{
    public class CreateRoleCommandHandler : ICommandHandler<CreateRoleCommand>
    {
        private readonly IRoleProccesing _roleProccesing;
        public CreateRoleCommandHandler(IRoleProccesing roleProccesing)
        {
            _roleProccesing = roleProccesing;
        }

        public async Task HandleAsync(CreateRoleCommand request)
        {
            var mapper = Mapping.CreateCommandRole(request);
            await _roleProccesing.CreateRoleAsync(mapper);
        }
    }
}
