using System;
using TimeSheet.Application.Abstraction;
using TimeSheet.Application.Dto;

namespace TimeSheet.Application.Queries.Activity.GetByIdAndDate
{
    public class GetTimeSheetByIdAndDate : IQuery<DataServiceMessage>
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
    }
}
