using System.Threading.Tasks;
using TimeSheet.Application.Abstraction;
using TimeSheet.Application.Contracts.View;
using TimeSheet.Application.Dto;

namespace TimeSheet.Application.Queries.Activity.GetByIdAndDate
{
    public class GetTimeSheetByIdAndDateHandler : IQueryHandler<GetTimeSheetByIdAndDate, DataServiceMessage>
    {
        private readonly IActivityView _activityView;
        public GetTimeSheetByIdAndDateHandler(IActivityView activityView)
        {
            _activityView = activityView;
        }
        public async Task<DataServiceMessage> HandleAsync(GetTimeSheetByIdAndDate query)
        {
            return await _activityView.GetTimeTrakingByIdAndDate(query.Id, query.Date);
        }
    }
}
