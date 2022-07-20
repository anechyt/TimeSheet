using Microsoft.AspNetCore.Mvc;
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
        public ActivityTypeController(ICommandHandler<CreateActivityTypeCommand> commandCreateActivityTypeHandler,
            ICommandHandler<DeleteActivityTypeCommand> commandDeleteActivityTypeHandler,
             ICommandHandler<UpdateActivityTypeCommand> commandUpdateActivityTypeHandler)
        {
            _commandCreateActivityTypeHandler = commandCreateActivityTypeHandler;
            _commandDeleteActivityTypeHandler = commandDeleteActivityTypeHandler;
            _commandUpdateActivityTypeHandler = commandUpdateActivityTypeHandler;
        }

        [HttpPost("activitytypes")]
        public async Task<ActionResult> CreateActivityType(CreateActivityTypeCommand createActivityTypeCommand)
        {
            await _commandCreateActivityTypeHandler.HandleAsync(createActivityTypeCommand);
            return Ok();
        }

        [HttpDelete("activitytypes/{id}")]
        public async Task<ActionResult> DeleteActivityType([FromQuery] DeleteActivityTypeCommand deleteActivityTypeCommand)
        {
            await _commandDeleteActivityTypeHandler.HandleAsync(deleteActivityTypeCommand);
            return Ok();
        }

        [HttpPut("updateactivitytype")]
        public async Task<ActionResult> UpdateActivityType(UpdateActivityTypeCommand updateActivityTypeCommand)
        {
            await _commandUpdateActivityTypeHandler.HandleAsync(updateActivityTypeCommand);
            return Ok();
        }
    }
}
