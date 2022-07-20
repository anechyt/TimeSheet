using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TimeSheet.Application.Contracts.Proccesing;
using TimeSheet.Application.Dto;
using TimeSheet.Application.Mapper;
using TimeSheet.Domain.Exceptions;
using TimeSheet.Infrastructure.Dal;
using static TimeSheet.Domain.Constants.ResponseMessage;

namespace TimeSheet.Infrastructure.Services.Proccesing
{
    public class ActivityProccesing : IActivityProccesing
    {
        private readonly TimeSheetContext _timeSheetContext;
        public ActivityProccesing(TimeSheetContext timeSheetContext)
        {
            _timeSheetContext = timeSheetContext;
        }
        public async Task<DataServiceMessage> CreateActivityAsync(CreateActivityDto createActivityDto)
        {
            var mapper = Mapping.CreateActivityDtoToActivity(createActivityDto);

            await _timeSheetContext.Activity.AddAsync(mapper);
            await _timeSheetContext.SaveChangesAsync();

            var data = new DataServiceMessage(true, GoodResponse.AddedSuccessfully, mapper);
            return data;
        }

        public async Task<DataServiceMessage> DeleteActivityAsync(DeleteActivityDto deleteActivityDto)
        {
            var activity = await _timeSheetContext.Activity.FirstOrDefaultAsync(x => x.Id == deleteActivityDto.Id);

            if (activity == null)
                throw new InvalidActivityException(deleteActivityDto.Id);

            _timeSheetContext.Activity.Remove(activity);
            await _timeSheetContext.SaveChangesAsync();

            var data = new DataServiceMessage(true, GoodResponse.DeletedSuccessfully, activity);
            return data;
        }

        public async Task<DataServiceMessage> UpdateActivityAsync(UpdateActivityDto updateActivityDto)
        {
            var activity = await _timeSheetContext.Activity.AsNoTracking().FirstOrDefaultAsync(x => x.Id == updateActivityDto.Id);

            if (activity == null)
                throw new InvalidActivityException(updateActivityDto.Id);

            var mapper = Mapping.UpdateActivityDtoToActivity(updateActivityDto);

            _timeSheetContext.Activity.Update(mapper);
            await _timeSheetContext.SaveChangesAsync();

            var data = new DataServiceMessage(true, GoodResponse.UpdatedSuccessfully, mapper);
            return data;
        }
    }
}
