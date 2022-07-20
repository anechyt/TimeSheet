using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using TimeSheet.Application.Contracts.Proccesing;
using TimeSheet.Application.Dto;
using TimeSheet.Application.Mapper;
using TimeSheet.Domain.Exceptions;
using TimeSheet.Infrastructure.Dal;
using static TimeSheet.Domain.Constants.ResponseMessage;

namespace TimeSheet.Infrastructure.Services.Proccesing
{
    public class ProjectProccesing : IProjectProccesing
    {
        private readonly TimeSheetContext _timeSheetContext;
        public ProjectProccesing(TimeSheetContext timeSheetContext)
        {
            _timeSheetContext = timeSheetContext;
        }

        public async Task<DataServiceMessage> CreateProjectAsync(CreateProjectDto createProjectDto)
        {
            var mapper = Mapping.CreateProjectDtoToProject(createProjectDto);

            await _timeSheetContext.Project.AddAsync(mapper);
            await _timeSheetContext.SaveChangesAsync();

            var data = new DataServiceMessage(true, GoodResponse.AddedSuccessfully, mapper);
            return data;
        }

        public async Task<DataServiceMessage> DeleteProjectAsync(DeleteProjectDto deleteProjectDto)
        {
            var project = await _timeSheetContext.Project.FirstOrDefaultAsync(x => x.Id == deleteProjectDto.Id);

            if (project == null)
                throw new InvalidProjectException(deleteProjectDto.Id);

            _timeSheetContext.Project.Remove(project);
            await _timeSheetContext.SaveChangesAsync();

            var data = new DataServiceMessage(true, GoodResponse.DeletedSuccessfully, project);
            return data;
        }

        public async Task<DataServiceMessage> UpdateProjectAsync(UpdateProjectDto updateProjectDto)
        {
            var project = await _timeSheetContext.Project.AsNoTracking().FirstOrDefaultAsync(x => x.Id == updateProjectDto.Id);

            if (project == null)
                throw new InvalidProjectException(updateProjectDto.Id);

            var mapper = Mapping.UpdateProjectDtoToProject(updateProjectDto);

            _timeSheetContext.Project.Update(mapper);
            await _timeSheetContext.SaveChangesAsync();

            var data = new DataServiceMessage(true, GoodResponse.UpdatedSuccessfully, mapper);
            return data;
        }
    }
}
