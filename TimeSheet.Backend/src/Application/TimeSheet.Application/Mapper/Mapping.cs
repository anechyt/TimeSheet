﻿using TimeSheet.Application.Commands.Activity.CreateActivity;
using TimeSheet.Application.Commands.ActivityType.CreateActivityType;
using TimeSheet.Application.Commands.Employee.CreateEmployee;
using TimeSheet.Application.Commands.Project.CreateProject;
using TimeSheet.Application.Commands.Role.CreateRole;
using TimeSheet.Application.Dto;
using TimeSheet.Domain.Entities;

namespace TimeSheet.Application.Mapper
{
    public static class Mapping
    {
        #region RoleDto to Role
        public static Role CreateRoleDtoToRole(this CreateRoleDto createRoleCommand)
        {
            return new Role
            {
                Name = createRoleCommand.Name
            };
        }

        public static Role UpdateRoleDtoToRole(this UpdateRoleDto updateRoleDto)
        {
            return new Role
            {
                Id = updateRoleDto.Id,
                Name = updateRoleDto.Name
            };
        }
        #endregion

        #region Role Command
        public static CreateRoleDto CreateCommandRole(this CreateRoleCommand createRoleCommand)
        {
            return new CreateRoleDto
            {
                Name = createRoleCommand.Name
            };
        }
        #endregion

        #region ProjectDto to Project
        public static Project CreateProjectDtoToProject(this CreateProjectDto createProjectDto)
        {
            return new Project
            {
                Name = createProjectDto.Name,
                DateStart = createProjectDto.DateStart,
                DateEnd = createProjectDto.DateEnd,

            };
        }
        public static Project UpdateProjectDtoToProject(this UpdateProjectDto updateProjectDto)
        {
            return new Project
            {
                Id = updateProjectDto.Id,
                Name = updateProjectDto.Name,
                DateStart = updateProjectDto.DateStart,
                DateEnd = updateProjectDto.DateEnd,
            };
        }
        #endregion

        #region Project Command
        public static CreateProjectDto CreateCommandProject(this CreateProjectCommand createProjectCommand)
        {
            return new CreateProjectDto
            {
                Name = createProjectCommand.Name,
                DateStart = createProjectCommand.DateStart,
                DateEnd = createProjectCommand.DateEnd,
            };
        }
        #endregion

        #region EmployeeDto to Employee
        public static Employee CreateEmployeeDtoToEmployee(this CreateEmployeeDto createEmployeeDto)
        {
            return new Employee
            {
                Name = createEmployeeDto.Name,
                Sex = createEmployeeDto.Sex,
                Birthday = createEmployeeDto.Birthday
            };
        }
        public static Employee UpdateEmployeeDtoToEmployee(this UpdateEmployeeDto updateEmployeeDto)
        {
            return new Employee
            {
                Id = updateEmployeeDto.Id,
                Name = updateEmployeeDto.Name,
                Sex = updateEmployeeDto.Sex,
                Birthday = updateEmployeeDto.Birthday
            };
        }
        #endregion

        #region Employee Command
        public static CreateEmployeeDto CreateCommandEmployee(this CreateEmployeeCommand createEmployeeCommand)
        {
            return new CreateEmployeeDto
            {
                Name = createEmployeeCommand.Name,
                Sex = createEmployeeCommand.Sex,
                Birthday = createEmployeeCommand.Birthday
            };
        }
        #endregion

        #region ActivityDto to Activity
        public static Activity CreateActivityDtoToActivity(this CreateActivityDto createActivityDto)
        {
            return new Activity
            {
                ProjectId = createActivityDto.ProjectId,
                RoleId = createActivityDto.RoleId,
                ActivityTypeId = createActivityDto.ActivityTypeId,
                EmployeeId = createActivityDto.EmployeeId,
            };
        }

        public static Activity UpdateActivityDtoToActivity(this UpdateActivityDto updateActivityDto)
        {
            return new Activity
            {
                Id = updateActivityDto.Id,
                ProjectId = updateActivityDto.ProjectId,
                RoleId = updateActivityDto.RoleId,
                ActivityTypeId = updateActivityDto.ActivityTypeId,
                EmployeeId = updateActivityDto.EmployeeId,
            };
        }
        #endregion

        #region Activity Command
        public static CreateActivityDto CreateCommandActivity(this CreateActivityCommand createActivityCommand)
        {
            return new CreateActivityDto
            {
                ActivityTypeId = createActivityCommand.ActivityTypeId,
                EmployeeId = createActivityCommand.EmployeeId,
                ProjectId = createActivityCommand.ProjectId,
                RoleId = createActivityCommand.RoleId,
            };
        }
        #endregion

        #region ActivityTypeDto to Activity
        public static ActivityType CreateActivityTypeDtoToActivityType(this CreateActivityTypeDto createActivityTypeDto)
        {
            return new ActivityType
            {
                Name = createActivityTypeDto.Name
            };
        }

        public static ActivityType UpdateActivityTypeDtoToActivityType(this UpdateActivityTypeDto updateActivityTypeDto)
        {
            return new ActivityType
            {
                Id = updateActivityTypeDto.Id,
                Name = updateActivityTypeDto.Name,
            };
        }
        #endregion

        #region ActivityType Command
        public static CreateActivityTypeDto CreateCommandActivityType(this CreateActivityTypeCommand createActivityTypeCommand)
        {
            return new CreateActivityTypeDto
            {
                Name = createActivityTypeCommand.Name,
            };
        }
        #endregion
    }
}
