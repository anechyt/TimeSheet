using Microsoft.AspNetCore.Mvc;
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
        public EmployeeController(ICommandHandler<CreateEmployeeCommand> commandCreateEmployeeHandler,
            ICommandHandler<DeleteEmployeeCommand> commandDeleteEmployeeHandler,
            ICommandHandler<UpdateEmployeeCommand> commandUpdateEmployeeHandler)
        {
            _commandCreateEmployeeHandler = commandCreateEmployeeHandler;
            _commandDeleteEmployeeHandler = commandDeleteEmployeeHandler;
            _commandUpdateEmployeeHandler = commandUpdateEmployeeHandler;
        }

        [HttpPost("employees")]
        public async Task<ActionResult> CreateEmployee(CreateEmployeeCommand createEmployeeCommand)
        {
            await _commandCreateEmployeeHandler.HandleAsync(createEmployeeCommand);
            return Ok();
        }

        [HttpDelete("deleteproject")]
        public async Task<ActionResult> DeleteEmployee(DeleteEmployeeCommand deleteEmployeeCommand)
        {
            await _commandDeleteEmployeeHandler.HandleAsync(deleteEmployeeCommand);
            return Ok();
        }

        [HttpPut("updateemployee")]
        public async Task<ActionResult> UpdateEmployee(UpdateEmployeeCommand updateEmployeeCommand)
        {
            await _commandUpdateEmployeeHandler.HandleAsync(updateEmployeeCommand);
            return Ok();
        }
    }
}
