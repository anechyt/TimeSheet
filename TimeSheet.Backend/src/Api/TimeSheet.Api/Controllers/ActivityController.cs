using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using TimeSheet.Application.Abstraction;
using TimeSheet.Application.Commands.Activity.CreateActivity;
using TimeSheet.Application.Commands.Activity.DeleteActivity;
using TimeSheet.Application.Commands.Activity.UpdateActivity;
using TimeSheet.Application.Dto;
using TimeSheet.Application.Queries.Activity.GetByIdAndDate;

namespace TimeSheet.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly ICommandHandler<CreateActivityCommand> _commandCreateActivityHandler;
        private readonly ICommandHandler<DeleteActivityCommand> _commandDeleteActivityHandler;
        private readonly ICommandHandler<UpdateActivityCommand> _commandUpdateActivityHandler;

        private readonly ILogger<ActivityController> _logger;

        private readonly IQueryHandler<GetTimeSheetByIdAndDate, DataServiceMessage> _queryTimeSheetByIdHandler;
        public ActivityController(ICommandHandler<CreateActivityCommand> commandCreateActivityHandler,
            ICommandHandler<DeleteActivityCommand> commandDeleteActivityHandler,
            ICommandHandler<UpdateActivityCommand> commandUpdateActivityHandler,
            IQueryHandler<GetTimeSheetByIdAndDate, DataServiceMessage> queryTimeSheetByIdHandler,
            ILogger<ActivityController> logger)
        {
            _commandCreateActivityHandler = commandCreateActivityHandler;
            _commandDeleteActivityHandler = commandDeleteActivityHandler;
            _commandUpdateActivityHandler = commandUpdateActivityHandler;
            _queryTimeSheetByIdHandler = queryTimeSheetByIdHandler;
            _logger = logger;
        }

        [HttpPost("activities")]
        public async Task<ActionResult> CreateActivity(CreateActivityCommand createActivityCommand)
        {
            await _commandCreateActivityHandler.HandleAsync(createActivityCommand);
            _logger.LogInformation("Created successfully a new item!");
            return Ok();
        }

        [HttpDelete("activities/{id}")]
        public async Task<ActionResult> DeleteActivity([FromQuery] DeleteActivityCommand deleteActivityCommand)
        {
            await _commandDeleteActivityHandler.HandleAsync(deleteActivityCommand);
            _logger.LogInformation("Deleted successfully item!");
            return Ok();
        }

        [HttpPut("activities")]
        public async Task<ActionResult> UpdateActivity(UpdateActivityCommand updateActivityCommand)
        {
            await _commandUpdateActivityHandler.HandleAsync(updateActivityCommand);
            _logger.LogInformation("Updated successfully item!");
            return Ok();
        }

        [HttpGet("activities")]
        public async Task<ActionResult> GetTimeTraking([FromQuery] GetTimeSheetByIdAndDate getTimeSheetByIdAndDate)
        {
            var result = await _queryTimeSheetByIdHandler.HandleAsync(getTimeSheetByIdAndDate);
            _logger.LogInformation("Get TimeTraking successfully!");
            return Ok(result);
        }
    }
}
