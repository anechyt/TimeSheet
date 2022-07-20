using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TimeSheet.Application.Contracts.Proccesing;
using TimeSheet.Application.Dto;
using TimeSheet.Application.Mapper;

namespace TimeSheet.Application.Commands.ActivityType.CreateActivityType
{
    public class CreateActivityTypeCommandHandler : IRequestHandler<CreateActivityTypeCommand, DataServiceMessage>
    {
        private readonly IActivityTypeProccesing _activityTypeProccesing;
        public CreateActivityTypeCommandHandler(IActivityTypeProccesing activityTypeProccesing)
        {
            _activityTypeProccesing = activityTypeProccesing;
        }
        public Task<DataServiceMessage> Handle(CreateActivityTypeCommand request, CancellationToken cancellationToken)
        {
            var mapper = Mapping.CreateCommandActivityType(request);
            var data = _activityTypeProccesing.CreateActivityTypeAsync(mapper);

            return data;
        }
    }
}
