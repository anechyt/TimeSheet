using System.Threading.Tasks;
using TimeSheet.Application.Abstraction;
using TimeSheet.Application.Contracts.Proccesing;
using TimeSheet.Application.Mapper;

namespace TimeSheet.Application.Commands.ActivityType.CreateActivityType
{
    public class CreateActivityTypeCommandHandler : ICommandHandler<CreateActivityTypeCommand>
    {
        private readonly IActivityTypeProccesing _activityTypeProccesing;
        public CreateActivityTypeCommandHandler(IActivityTypeProccesing activityTypeProccesing)
        {
            _activityTypeProccesing = activityTypeProccesing;
        }
        public async Task HandleAsync(CreateActivityTypeCommand request)
        {
            var mapper = Mapping.CreateCommandActivityType(request);
            await _activityTypeProccesing.CreateActivityTypeAsync(mapper);
        }
    }
}
