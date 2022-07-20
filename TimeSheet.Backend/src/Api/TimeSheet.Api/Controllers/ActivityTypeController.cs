using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using TimeSheet.Application.Abstraction;
using TimeSheet.Application.Commands.ActivityType.CreateActivityType;
using TimeSheet.Application.Commands.ActivityType.DeleteActivityType;
using TimeSheet.Application.Commands.ActivityType.UpdateActivityType;

namespace TimeSheet.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityTypeController : ControllerBase
    {
        private readonly ICommandHandler<CreateActivityTypeCommand> _commandCreateActivityTypeHandler;
        private readonly ICommandHandler<DeleteActivityTypeCommand> _commandDeleteActivityTypeHandler;
        private readonly ICommandHandler<UpdateActivityTypeCommand> _commandUpdateActivityTypeHandler;

        private readonly ILogger<ActivityTypeController> _logger;
        public ActivityTypeController(ICommandHandler<CreateActivityTypeCommand> commandCreateActivityTypeHandler,
            ICommandHandler<DeleteActivityTypeCommand> commandDeleteActivityTypeHandler,
             ICommandHandler<UpdateActivityTypeCommand> commandUpdateActivityTypeHandler,
             ILogger<ActivityTypeController> logger)
        {
            _commandCreateActivityTypeHandler = commandCreateActivityTypeHandler;
            _commandDeleteActivityTypeHandler = commandDeleteActivityTypeHandler;
            _commandUpdateActivityTypeHandler = commandUpdateActivityTypeHandler;
            _logger = logger;
        }

        [HttpPost("activitytypes")]
        public async Task<ActionResult> CreateActivityType(CreateActivityTypeCommand createActivityTypeCommand)
        {
            await _commandCreateActivityTypeHandler.HandleAsync(createActivityTypeCommand);
            _logger.LogInformation("Created successfully a new item!");
            return Ok();
        }

        [HttpDelete("activitytypes/{id}")]
        public async Task<ActionResult> DeleteActivityType([FromQuery] DeleteActivityTypeCommand deleteActivityTypeCommand)
        {
            await _commandDeleteActivityTypeHandler.HandleAsync(deleteActivityTypeCommand);
            _logger.LogInformation("Deleted successfully item!");
            return Ok();
        }

        [HttpPut("activitytypes")]
        public async Task<ActionResult> UpdateActivityType(UpdateActivityTypeCommand updateActivityTypeCommand)
        {
            await _commandUpdateActivityTypeHandler.HandleAsync(updateActivityTypeCommand);
            _logger.LogInformation("Updated successfully item!");
            return Ok();
        }
    }
}
