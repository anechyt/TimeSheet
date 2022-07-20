using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using TimeSheet.Application.Abstraction;
using TimeSheet.Application.Commands.Role.CreateRole;
using TimeSheet.Application.Commands.Role.DeleteRole;
using TimeSheet.Application.Commands.Role.UpdateRole;

namespace TimeSheet.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly ICommandHandler<CreateRoleCommand> _commandCreateRoleHandler;
        private readonly ICommandHandler<DeleteRoleCommand> _commandDeleteRoleHandler;
        private readonly ICommandHandler<UpdateRoleCommand> _commandUpdateRoleHandler;

        private readonly ILogger<RoleController> _logger;

        public RoleController(ICommandHandler<CreateRoleCommand> commandCreateRoleHandler,
            ICommandHandler<DeleteRoleCommand> commandDeleteRoleHandler,
            ICommandHandler<UpdateRoleCommand> commandUpdateRoleHandler,
            ILogger<RoleController> logger)
        {
            _commandCreateRoleHandler = commandCreateRoleHandler;
            _commandDeleteRoleHandler = commandDeleteRoleHandler;
            _commandUpdateRoleHandler = commandUpdateRoleHandler;
            _logger = logger;
        }

        [HttpPost("roles")]
        public async Task<ActionResult> CreateRole(CreateRoleCommand createRoleCommand)
        {
            await _commandCreateRoleHandler.HandleAsync(createRoleCommand);
            _logger.LogInformation("Created successfully a new item!");
            return Ok();
        }

        [HttpDelete("roles/{id}")]
        public async Task<ActionResult> DeleteRole([FromQuery] DeleteRoleCommand deleteRoleCommand)
        {
            await _commandDeleteRoleHandler.HandleAsync(deleteRoleCommand);
            _logger.LogInformation("Deleted successfully item!");
            return Ok();
        }

        [HttpPut("roles")]
        public async Task<ActionResult> UpdateRole(UpdateRoleCommand updateRoleCommand)
        {
            await _commandUpdateRoleHandler.HandleAsync(updateRoleCommand);
            _logger.LogInformation("Updated successfully item!");
            return Ok();
        }
    }
}
