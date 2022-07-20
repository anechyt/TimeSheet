using TimeSheet.Application.Abstraction;

namespace TimeSheet.Application.Commands.ActivityType.DeleteActivityType
{
    public class DeleteActivityTypeCommand : ICommand
    {
        public int Id { get; set; }
    }
}
