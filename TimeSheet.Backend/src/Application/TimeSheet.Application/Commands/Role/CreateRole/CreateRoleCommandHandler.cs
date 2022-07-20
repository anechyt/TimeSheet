using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TimeSheet.Application.Contracts.Proccesing;
using TimeSheet.Application.Dto;
using TimeSheet.Application.Mapper;

namespace TimeSheet.Application.Commands.Role.CreateRole
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, DataServiceMessage>
    {
        private readonly IRoleProccesing _roleProccesing;
        public CreateRoleCommandHandler(IRoleProccesing roleProccesing)
        {
            _roleProccesing = roleProccesing;
        }

        public async Task<DataServiceMessage> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            var mapper = Mapping.CreateCommandRole(request);
            var data = await _roleProccesing.CreateRoleAsync(mapper);

            return data;
        }
    }
}
