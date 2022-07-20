using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Application.Contracts.View;
using TimeSheet.Application.Dto;
using TimeSheet.Domain.Exceptions;
using TimeSheet.Infrastructure.Dal;
using static TimeSheet.Domain.Constants.ResponseMessage;

namespace TimeSheet.Infrastructure.Services.View
{
    public class ActivityView : IActivityView
    {
        private readonly TimeSheetContext _timeSheetContext;
        public ActivityView(TimeSheetContext timeSheetContext)
        {
            _timeSheetContext = timeSheetContext;
        }
        public async Task<DataServiceMessage> GetTimeTrakingByIdAndDate(int id, DateTime date)
        {
            var excsistingActivity = await _timeSheetContext.Activity.Where(x => x.EmployeeId == id).ToListAsync();
            if (excsistingActivity == null)
                throw new InvalidEmployeeException(id);

            var excsistingData = await _timeSheetContext.Project.Where(e => e.DateEnd == date).ToListAsync();
            if (excsistingData == null)
                throw new Exception("Date is Invalid!");

            var dataActivity = await _timeSheetContext.Activity.Join(_timeSheetContext.Project,
                c => c.ProjectId,
                i => i.Id, 
                (c, i) => new
                {
                    Project = c.Project.Name,
                    ProjectDate = c.Project.DateEnd,
                    Role = c.Role.Name,
                    ActivityType = c.ActivityType.Name,
                    Employee = c.Employee.Name

                }).ToListAsync();

            List<string> list = new List<string>();
            foreach (var activity in dataActivity)
            {
                string result = $"{activity.ProjectDate} as a {activity.Role} {activity.Employee}" +
                    $" worked on the {activity.Project} 8 hours {activity.ActivityType}" +
                    $" but {activity.ProjectDate} as a {activity.Role} {activity.Employee}" +
                    $" worked on the {activity.Project} 2 hours {activity.ActivityType} and 6 hours as a" +
                    $" {activity.Role} on the {activity.Project} {activity.ActivityType}";
                list.Add(result);
            }

            var data = new DataServiceMessage(true, GoodResponse.GetSuccessfully, list);
            return data;
        }

        public Task<DataServiceMessage> GetTimeTrakingByIdAndWeek(int id, int week)
        {
            throw new NotImplementedException();
        }
    }
}
