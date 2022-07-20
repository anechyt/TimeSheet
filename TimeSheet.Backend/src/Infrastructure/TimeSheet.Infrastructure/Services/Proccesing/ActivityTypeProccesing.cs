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
    public class ActivityTypeProccesing : IActivityTypeProccesing
    {
        private readonly TimeSheetContext _timeSheetContext;
        public ActivityTypeProccesing(TimeSheetContext timeSheetContext)
        {
            _timeSheetContext = timeSheetContext;
        }

        public async Task<DataServiceMessage> CreateActivityTypeAsync(CreateActivityTypeDto createActivityTypeDto)
        {
            var mapper = Mapping.CreateActivityTypeDtoToActivityType(createActivityTypeDto);

            await _timeSheetContext.ActivityType.AddAsync(mapper);
            await _timeSheetContext.SaveChangesAsync();

            var data = new DataServiceMessage(true, GoodResponse.AddedSuccessfully, mapper);
            return data;
        }

        public async Task<DataServiceMessage> DeleteActivityTypeAsync(DeleteActivityTypeDto deleteActivityTypeDto)
        {
            var activityType = await _timeSheetContext.ActivityType.FirstOrDefaultAsync(x => x.Id == deleteActivityTypeDto.Id);

            if (activityType == null)
                throw new InvalidActivityTypeException(deleteActivityTypeDto.Id);

            _timeSheetContext.ActivityType.Remove(activityType);
            await _timeSheetContext.SaveChangesAsync();

            var data = new DataServiceMessage(true, GoodResponse.DeletedSuccessfully, activityType);
            return data;
        }

        public async Task<DataServiceMessage> UpdateActivityTypeAsync(UpdateActivityTypeDto updateActivityTypeDto)
        {
            var activityType = await _timeSheetContext.ActivityType.AsNoTracking().FirstOrDefaultAsync(x => x.Id == updateActivityTypeDto.Id);

            if (activityType == null)
                throw new InvalidActivityTypeException(updateActivityTypeDto.Id);

            var mapper = Mapping.UpdateActivityTypeDtoToActivityType(updateActivityTypeDto);

            _timeSheetContext.ActivityType.Update(mapper);
            await _timeSheetContext.SaveChangesAsync();

            var data = new DataServiceMessage(true, GoodResponse.AddedSuccessfully, mapper);
            return data;
        }
    }
}
