using System.Threading.Tasks;
using TimeSheet.Application.Abstraction;
using TimeSheet.Application.Contracts.Proccesing;
using TimeSheet.Application.Mapper;

namespace TimeSheet.Application.Commands.Activity.CreateActivity
{
    public class CreateActivityCommandHandler : ICommandHandler<CreateActivityCommand>
    {
        private readonly IActivityProccesing _activityProccesing;
        public CreateActivityCommandHandler(IActivityProccesing activityProccesing)
        {
            _activityProccesing = activityProccesing;
        }

        public async Task HandleAsync(CreateActivityCommand request)
        {
            var mapper = Mapping.CreateCommandActivity(request);
            await _activityProccesing.CreateActivityAsync(mapper);
        }
    }
}
