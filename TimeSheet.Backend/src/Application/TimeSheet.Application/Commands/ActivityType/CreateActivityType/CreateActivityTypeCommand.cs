using MediatR;
using TimeSheet.Application.Dto;

namespace TimeSheet.Application.Commands.ActivityType.CreateActivityType
{
    public class CreateActivityTypeCommand : IRequest<DataServiceMessage>
    {
        public string Name { get; set; }
    }
}
