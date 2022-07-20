using System.Threading.Tasks;
using TimeSheet.Application.Abstraction;
using TimeSheet.Application.Contracts.Proccesing;
using TimeSheet.Application.Mapper;

namespace TimeSheet.Application.Commands.Activity.UpdateActivity
{
    public class UpdateActivityCommandHandler : ICommandHandler<UpdateActivityCommand>
    {
        private readonly IActivityProccesing _activityProccesing;
        public UpdateActivityCommandHandler(IActivityProccesing activityProccesing)
        {
            _activityProccesing = activityProccesing;
        }
        public async Task HandleAsync(UpdateActivityCommand command)
        {
            var mapper = Mapping.UpdateCommandActivity(command);
            await _activityProccesing.UpdateActivityAsync(mapper);
        }
    }
}
