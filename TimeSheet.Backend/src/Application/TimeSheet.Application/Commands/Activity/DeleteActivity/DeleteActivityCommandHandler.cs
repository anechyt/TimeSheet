using System.Threading.Tasks;
using TimeSheet.Application.Abstraction;
using TimeSheet.Application.Contracts.Proccesing;
using TimeSheet.Application.Mapper;

namespace TimeSheet.Application.Commands.Activity.DeleteActivity
{
    public class DeleteActivityCommandHandler : ICommandHandler<DeleteActivityCommand>
    {
        private readonly IActivityProccesing _activityProccesing;
        public DeleteActivityCommandHandler(IActivityProccesing activityProccesing)
        {
            _activityProccesing = activityProccesing;
        }
        public async Task HandleAsync(DeleteActivityCommand command)
        {
            var mapper = Mapping.DeleteCommandActivity(command);
            await _activityProccesing.DeleteActivityAsync(mapper);
        }
    }
}
