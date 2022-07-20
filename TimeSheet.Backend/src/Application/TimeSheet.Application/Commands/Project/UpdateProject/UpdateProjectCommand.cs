using System;
using TimeSheet.Application.Abstraction;

namespace TimeSheet.Application.Commands.Project.UpdateProject
{
    public class UpdateProjectCommand : ICommand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
    }
}
