using System;
using System.Threading.Tasks;
using TimeSheet.Application.Dto;

namespace TimeSheet.Application.Contracts.View
{
    public interface IActivityView
    {
        Task<DataServiceMessage> GetTimeTrakingByIdAndDate(int id, DateTime date);
        Task<DataServiceMessage> GetTimeTrakingByIdAndWeek(int id, int week);

    }
}
