using Microsoft.Extensions.DependencyInjection;
using TimeSheet.Application.Abstraction;
using TimeSheet.Application.Commands.Activity.CreateActivity;
using TimeSheet.Application.Commands.Activity.DeleteActivity;
using TimeSheet.Application.Commands.Activity.UpdateActivity;
using TimeSheet.Application.Commands.ActivityType.CreateActivityType;
using TimeSheet.Application.Commands.ActivityType.DeleteActivityType;
using TimeSheet.Application.Commands.ActivityType.UpdateActivityType;
using TimeSheet.Application.Commands.Employee.CreateEmployee;
using TimeSheet.Application.Commands.Employee.DeleteEmployee;
using TimeSheet.Application.Commands.Employee.UpdateEmployee;
using TimeSheet.Application.Commands.Project.CreateProject;
using TimeSheet.Application.Commands.Project.DeleteProject;
using TimeSheet.Application.Commands.Project.UpdateProject;
using TimeSheet.Application.Commands.Role.CreateRole;
using TimeSheet.Application.Commands.Role.DeleteRole;
using TimeSheet.Application.Commands.Role.UpdateRole;
using TimeSheet.Application.Dto;
using TimeSheet.Application.Queries.Activity.GetByIdAndDate;
using TimeSheet.Application.Queries.Project.GetAll;
using TimeSheet.Application.Queries.Project.GetById;

namespace TimeSheet.Application.Extensions
{
    public static class Extension
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            #region Role
            services.AddScoped<ICommand, CreateRoleCommand>();
            services.AddScoped<ICommand, DeleteRoleCommand>();
            services.AddScoped<ICommand, UpdateRoleCommand>();

            services.AddScoped<ICommandHandler<CreateRoleCommand>, CreateRoleCommandHandler>();
            services.AddScoped<ICommandHandler<DeleteRoleCommand>, DeleteRoleCommandHandler>();
            services.AddScoped<ICommandHandler<UpdateRoleCommand>, UpdateRoleCommandHandler>();
            #endregion

            #region Activity
            services.AddScoped<IQuery<DataServiceMessage>, GetTimeSheetByIdAndDate>();
            services.AddScoped<IQueryHandler<GetTimeSheetByIdAndDate, DataServiceMessage>, GetTimeSheetByIdAndDateHandler>();

            services.AddScoped<ICommand, CreateActivityCommand>();
            services.AddScoped<ICommand, DeleteActivityCommand>();
            services.AddScoped<ICommand, UpdateActivityCommand>();

            services.AddScoped<ICommandHandler<CreateActivityCommand>, CreateActivityCommandHandler>();
            services.AddScoped<ICommandHandler<DeleteActivityCommand>, DeleteActivityCommandHandler>();
            services.AddScoped<ICommandHandler<UpdateActivityCommand>, UpdateActivityCommandHandler>();
            #endregion

            #region ActivityType
            services.AddScoped<ICommand, CreateActivityTypeCommand>();
            services.AddScoped<ICommand, DeleteActivityTypeCommand>();
            services.AddScoped<ICommand, UpdateActivityTypeCommand>();

            services.AddScoped<ICommandHandler<CreateActivityTypeCommand>, CreateActivityTypeCommandHandler>();
            services.AddScoped<ICommandHandler<DeleteActivityTypeCommand>, DeleteActivityTypeCommandHandler>();
            services.AddScoped<ICommandHandler<UpdateActivityTypeCommand>, UpdateActivityTypeCommandHandler>();
            #endregion

            #region Project
            services.AddScoped<IQuery<DataServiceMessage>, GetProjects>();
            services.AddScoped<IQuery<DataServiceMessage>, GetProjectsById>();

            services.AddScoped<IQueryHandler<GetProjects, DataServiceMessage>, GetProjectsHandler>();
            services.AddScoped<IQueryHandler<GetProjectsById, DataServiceMessage>, GetProjectsByIdHandler>();


            services.AddScoped<ICommand, CreateProjectCommand>();
            services.AddScoped<ICommand, DeleteProjectCommand>();
            services.AddScoped<ICommand, UpdateProjectCommand>();

            services.AddScoped<ICommandHandler<CreateProjectCommand>, CreateProjectCommandHandler>();
            services.AddScoped<ICommandHandler<DeleteProjectCommand>, DeleteProjectCommandHandler>();
            services.AddScoped<ICommandHandler<UpdateProjectCommand>, UpdateProjectCommandHandler>();
            #endregion

            #region Employee
            services.AddScoped<ICommand, CreateEmployeeCommand>();
            services.AddScoped<ICommand, DeleteEmployeeCommand>();
            services.AddScoped<ICommand, UpdateEmployeeCommand>();

            services.AddScoped<ICommandHandler<CreateEmployeeCommand>, CreateEmployeeCommandHandler>();
            services.AddScoped<ICommandHandler<DeleteEmployeeCommand>, DeleteEmployeeCommandHandler>();
            services.AddScoped<ICommandHandler<UpdateEmployeeCommand>, UpdateEmployeeCommandHandler>();
            #endregion

            return services;
        }
    }
}
