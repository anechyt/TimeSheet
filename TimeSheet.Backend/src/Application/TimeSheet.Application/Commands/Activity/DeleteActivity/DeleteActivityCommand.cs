using TimeSheet.Application.Abstraction;

namespace TimeSheet.Application.Commands.Activity.DeleteActivity
{
    public class DeleteActivityCommand : ICommand
    {
        public int Id { get; set; }
    }
}
