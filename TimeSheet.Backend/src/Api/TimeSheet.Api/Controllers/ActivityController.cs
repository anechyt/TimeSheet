using Microsoft.AspNetCore.Mvc;
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

        private readonly IQueryHandler<GetTimeSheetByIdAndDate, DataServiceMessage> _queryTimeSheetByIdHandler;
        public ActivityController(ICommandHandler<CreateActivityCommand> commandCreateActivityHandler,
            ICommandHandler<DeleteActivityCommand> commandDeleteActivityHandler,
            ICommandHandler<UpdateActivityCommand> commandUpdateActivityHandler,
            IQueryHandler<GetTimeSheetByIdAndDate, DataServiceMessage> queryTimeSheetByIdHandler)
        {
            _commandCreateActivityHandler = commandCreateActivityHandler;
            _commandDeleteActivityHandler = commandDeleteActivityHandler;
            _commandUpdateActivityHandler = commandUpdateActivityHandler;
            _queryTimeSheetByIdHandler = queryTimeSheetByIdHandler;
        }

        [HttpPost("activities")]
        public async Task<ActionResult> CreateActivity(CreateActivityCommand createActivityCommand)
        {
            await _commandCreateActivityHandler.HandleAsync(createActivityCommand);
            return Ok();
        }

        [HttpDelete("deleteactivity")]
        public async Task<ActionResult> DeleteActivity(DeleteActivityCommand deleteActivityCommand)
        {
            await _commandDeleteActivityHandler.HandleAsync(deleteActivityCommand);
            return Ok();
        }

        [HttpPut("updateactivity")]
        public async Task<ActionResult> UpdateActivity(UpdateActivityCommand updateActivityCommand)
        {
            await _commandUpdateActivityHandler.HandleAsync(updateActivityCommand);
            return Ok();
        }

        [HttpGet("gettimetraking")]
        public async Task<ActionResult> GetTimeTraking([FromQuery] GetTimeSheetByIdAndDate getTimeSheetByIdAndDate)
        {
            var result = await _queryTimeSheetByIdHandler.HandleAsync(getTimeSheetByIdAndDate);
            return Ok(result);
        }
    }
}
