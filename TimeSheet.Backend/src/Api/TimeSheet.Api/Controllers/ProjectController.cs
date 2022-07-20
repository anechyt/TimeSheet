using MediatR;
using Microsoft.AspNetCore.Mvc;
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
        public ProjectController(IQueryHandler<GetProjectsById, DataServiceMessage> queryProjectByIdHandler,
            IQueryHandler<GetProjects, DataServiceMessage> queryProjectHandler,
            ICommandHandler<CreateProjectCommand> commandCreateProjectHandler,
            ICommandHandler<DeleteProjectCommand> commandDeleteProjectHandler,
            ICommandHandler<UpdateProjectCommand> commandUpdateProjectHandler)
        {
            _queryProjectHandler = queryProjectHandler;
            _queryProjectByIdHandler = queryProjectByIdHandler;
            _commandCreateProjectHandler = commandCreateProjectHandler;
            _commandDeleteProjectHandler = commandDeleteProjectHandler;
            _commandUpdateProjectHandler = commandUpdateProjectHandler;
        }

        [HttpPost("projects")]
        public async Task<ActionResult> CreateProject(CreateProjectCommand createProjectCommand)
        {
            await _commandCreateProjectHandler.HandleAsync(createProjectCommand);
            return Ok();
        }

        [HttpDelete("projects/{id}")]
        public async Task<ActionResult> DeleteProject([FromQuery] DeleteProjectCommand deleteProjectCommand)
        {
            await _commandDeleteProjectHandler.HandleAsync(deleteProjectCommand);
            return Ok();
        }

        [HttpPut("updateproject")]
        public async Task<ActionResult> UpdateProject(UpdateProjectCommand updateProjectCommand)
        {
            await _commandUpdateProjectHandler.HandleAsync(updateProjectCommand);
            return Ok();
        }

        [HttpGet("allprojects")]
        public async Task<ActionResult> GetAllProjects([FromQuery] GetProjects getProjects)
        {
            var result = await _queryProjectHandler.HandleAsync(getProjects);
            return Ok(result);
        }

        [HttpGet("projects/{id}")]
        public async Task<ActionResult> GetProjectById([FromQuery] GetProjectsById getProjectById)
        {
            var result = await _queryProjectByIdHandler.HandleAsync(getProjectById);
            return Ok(result);
        }
    }
}
