using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TimeSheet.Application.Contracts.View;
using TimeSheet.Application.Dto;
using TimeSheet.Infrastructure.Dal;
using static TimeSheet.Domain.Constants.ResponseMessage;

namespace TimeSheet.Infrastructure.Services.View
{
    public class ProjectView : IProjectView
    {
        private readonly TimeSheetContext _timeSheetContext;
        public ProjectView(TimeSheetContext timeSheetContext)
        {
            _timeSheetContext = timeSheetContext;
        }
        public async Task<DataServiceMessage> GetAllProjects()
        {
            var result = await _timeSheetContext.Project.ToListAsync();
            var data = new DataServiceMessage(true, GoodResponse.GetSuccessfully, result);

            return data;
        }

        public async Task<DataServiceMessage> GetProjectById(int id)
        {
            var result = await _timeSheetContext.Project.FirstOrDefaultAsync(x => x.Id == id);
            var data = new DataServiceMessage(true, GoodResponse.GetSuccessfully, result);

            return data;
        }
    }
}
