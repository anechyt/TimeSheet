using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using TimeSheet.Application.Abstraction;
using TimeSheet.Application.Commands.Employee.CreateEmployee;
using TimeSheet.Application.Commands.Employee.DeleteEmployee;
using TimeSheet.Application.Commands.Employee.UpdateEmployee;

namespace TimeSheet.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ICommandHandler<CreateEmployeeCommand> _commandCreateEmployeeHandler;
        private readonly ICommandHandler<DeleteEmployeeCommand> _commandDeleteEmployeeHandler;
        private readonly ICommandHandler<UpdateEmployeeCommand> _commandUpdateEmployeeHandler;

        private readonly ILogger<EmployeeController> _logger;
        public EmployeeController(ICommandHandler<CreateEmployeeCommand> commandCreateEmployeeHandler,
            ICommandHandler<DeleteEmployeeCommand> commandDeleteEmployeeHandler,
            ICommandHandler<UpdateEmployeeCommand> commandUpdateEmployeeHandler,
            ILogger<EmployeeController> logger)
        {
            _commandCreateEmployeeHandler = commandCreateEmployeeHandler;
            _commandDeleteEmployeeHandler = commandDeleteEmployeeHandler;
            _commandUpdateEmployeeHandler = commandUpdateEmployeeHandler;
            _logger = logger;
        }

        [HttpPost("employees")]
        public async Task<ActionResult> CreateEmployee(CreateEmployeeCommand createEmployeeCommand)
        {
            await _commandCreateEmployeeHandler.HandleAsync(createEmployeeCommand);
            _logger.LogInformation("Created successfully a new item!");
            return Ok();
        }

        [HttpDelete("employees/{id}")]
        public async Task<ActionResult> DeleteEmployee([FromQuery] DeleteEmployeeCommand deleteEmployeeCommand)
        {
            await _commandDeleteEmployeeHandler.HandleAsync(deleteEmployeeCommand);
            _logger.LogInformation("Deleted successfully item!");
            return Ok();
        }

        [HttpPut("employees")]
        public async Task<ActionResult> UpdateEmployee(UpdateEmployeeCommand updateEmployeeCommand)
        {
            await _commandUpdateEmployeeHandler.HandleAsync(updateEmployeeCommand);
            _logger.LogInformation("Updated successfully item!");
            return Ok();
        }
    }
}
