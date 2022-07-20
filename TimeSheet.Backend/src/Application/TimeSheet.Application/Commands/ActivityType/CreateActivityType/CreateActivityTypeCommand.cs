using TimeSheet.Application.Abstraction;

namespace TimeSheet.Application.Commands.ActivityType.CreateActivityType
{
    public class CreateActivityTypeCommand : ICommand
    {
        public string Name { get; set; }
    }
}
