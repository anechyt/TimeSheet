using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using TimeSheet.Application.Abstraction;
using TimeSheet.Application.Commands.Project.CreateProject;
using TimeSheet.Application.Commands.Project.DeleteProject;
using TimeSheet.Application.Commands.Project.UpdateProject;
using TimeSheet.Application.Dto;
using TimeSheet.Application.Queries.Project.GetAll;
using TimeSheet.Application.Queries.Project.GetById;

namespace TimeSheet.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IQueryHandler<GetProjects, DataServiceMessage> _queryProjectHandler;
        private readonly IQueryHandler<GetProjectsById, DataServiceMessage> _queryProjectByIdHandler;

        private readonly ICommandHandler<CreateProjectCommand> _commandCreateProjectHandler;
        private readonly ICommandHandler<DeleteProjectCommand> _commandDeleteProjectHandler;
        private readonly ICommandHandler<UpdateProjectCommand> _commandUpdateProjectHandler;

        private readonly ILogger<ProjectController> _logger;
        public ProjectController(IQueryHandler<GetProjectsById, DataServiceMessage> queryProjectByIdHandler,
            IQueryHandler<GetProjects, DataServiceMessage> queryProjectHandler,
            ICommandHandler<CreateProjectCommand> commandCreateProjectHandler,
            ICommandHandler<DeleteProjectCommand> commandDeleteProjectHandler,
            ICommandHandler<UpdateProjectCommand> commandUpdateProjectHandler,
            ILogger<ProjectController> logger)
        {
            _queryProjectHandler = queryProjectHandler;
            _queryProjectByIdHandler = queryProjectByIdHandler;
            _commandCreateProjectHandler = commandCreateProjectHandler;
            _commandDeleteProjectHandler = commandDeleteProjectHandler;
            _commandUpdateProjectHandler = commandUpdateProjectHandler;
            _logger = logger;
        }

        [HttpPost("projects")]
        public async Task<ActionResult> CreateProject(CreateProjectCommand createProjectCommand)
        {
            await _commandCreateProjectHandler.HandleAsync(createProjectCommand);
            _logger.LogInformation("Created successfully a new item!");
            return Ok();
        }

        [HttpDelete("projects/{id}")]
        public async Task<ActionResult> DeleteProject([FromQuery] DeleteProjectCommand deleteProjectCommand)
        {
            await _commandDeleteProjectHandler.HandleAsync(deleteProjectCommand);
            _logger.LogInformation("Deleted successfully item!");
            return Ok();
        }

        [HttpPut("projects")]
        public async Task<ActionResult> UpdateProject(UpdateProjectCommand updateProjectCommand)
        {
            await _commandUpdateProjectHandler.HandleAsync(updateProjectCommand);
            _logger.LogInformation("Updated successfully item!");
            return Ok();
        }

        [HttpGet("projects")]
        public async Task<ActionResult> GetAllProjects([FromQuery] GetProjects getProjects)
        {
            var result = await _queryProjectHandler.HandleAsync(getProjects);
            _logger.LogInformation("Get successfully items!");
            return Ok(result);
        }

        [HttpGet("projects/{id}")]
        public async Task<ActionResult> GetProjectById([FromQuery] GetProjectsById getProjectById)
        {
            var result = await _queryProjectByIdHandler.HandleAsync(getProjectById);
            _logger.LogInformation("Get successfully items by id!");
            return Ok(result);
        }
    }
}
