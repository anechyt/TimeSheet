using System.Threading.Tasks;
using TimeSheet.Application.Abstraction;
using TimeSheet.Application.Contracts.Proccesing;
using TimeSheet.Application.Mapper;

namespace TimeSheet.Application.Commands.ActivityType.UpdateActivityType
{
    public class UpdateActivityTypeCommandHandler : ICommandHandler<UpdateActivityTypeCommand>
    {
        private readonly IActivityTypeProccesing _activityTypeProccesing;
        public UpdateActivityTypeCommandHandler(IActivityTypeProccesing activityTypeProccesing)
        {
            _activityTypeProccesing = activityTypeProccesing;
        }
        public async Task HandleAsync(UpdateActivityTypeCommand command)
        {
            var mapper = Mapping.UpdateCommandActivityType(command);
            await _activityTypeProccesing.UpdateActivityTypeAsync(mapper);
        }
    }
}
