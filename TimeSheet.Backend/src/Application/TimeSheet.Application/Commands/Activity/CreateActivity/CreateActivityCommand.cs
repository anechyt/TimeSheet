using MediatR;
using TimeSheet.Application.Dto;

namespace TimeSheet.Application.Commands.Activity.CreateActivity
{
    public class CreateActivityCommand : IRequest<DataServiceMessage>
    {
        public int ProjectId { get; set; }
        public int RoleId { get; set; }
        public int ActivityTypeId { get; set; }
        public int EmployeeId { get; set; }
    }
}
