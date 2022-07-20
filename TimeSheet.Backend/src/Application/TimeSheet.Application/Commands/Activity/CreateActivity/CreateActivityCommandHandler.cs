using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TimeSheet.Application.Contracts.Proccesing;
using TimeSheet.Application.Dto;
using TimeSheet.Application.Mapper;

namespace TimeSheet.Application.Commands.Activity.CreateActivity
{
    public class CreateActivityCommandHandler : IRequestHandler<CreateActivityCommand, DataServiceMessage>
    {
        private readonly IActivityProccesing _activityProccesing;
        public CreateActivityCommandHandler(IActivityProccesing activityProccesing)
        {
            _activityProccesing = activityProccesing;
        }

        public Task<DataServiceMessage> Handle(CreateActivityCommand request, CancellationToken cancellationToken)
        {
            var mapper = Mapping.CreateCommandActivity(request);
            var data = _activityProccesing.CreateActivityAsync(mapper);

            return data;
        }
    }
}
