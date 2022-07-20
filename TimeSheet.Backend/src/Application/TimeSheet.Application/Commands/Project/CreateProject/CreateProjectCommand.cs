using System;
using TimeSheet.Application.Abstraction;

namespace TimeSheet.Application.Commands.Project.CreateProject
{
    public class CreateProjectCommand : ICommand
    {
        public string Name { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
    }
}
