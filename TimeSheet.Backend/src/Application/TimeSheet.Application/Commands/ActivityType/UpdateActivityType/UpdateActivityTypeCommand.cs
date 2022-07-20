using TimeSheet.Application.Abstraction;

namespace TimeSheet.Application.Commands.ActivityType.UpdateActivityType
{
    public class UpdateActivityTypeCommand : ICommand
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
