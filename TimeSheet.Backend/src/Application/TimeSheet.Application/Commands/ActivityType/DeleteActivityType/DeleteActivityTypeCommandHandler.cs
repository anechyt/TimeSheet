using System.Threading.Tasks;
using TimeSheet.Application.Abstraction;
using TimeSheet.Application.Contracts.Proccesing;
using TimeSheet.Application.Mapper;

namespace TimeSheet.Application.Commands.ActivityType.DeleteActivityType
{
    public class DeleteActivityTypeCommandHandler : ICommandHandler<DeleteActivityTypeCommand>
    {
        private readonly IActivityTypeProccesing _activityTypeProccesing;
        public DeleteActivityTypeCommandHandler(IActivityTypeProccesing activityTypeProccesing)
        {
            _activityTypeProccesing = activityTypeProccesing;
        }
        public async Task HandleAsync(DeleteActivityTypeCommand command)
        {
            var mapper = Mapping.DeleteCommandActivityType(command);
            await _activityTypeProccesing.DeleteActivityTypeAsync(mapper);
        }
    }
}
