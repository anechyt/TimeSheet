using MediatR;
using System;
using TimeSheet.Application.Dto;

namespace TimeSheet.Application.Commands.Project.CreateProject
{
    public class CreateProjectCommand : IRequest<DataServiceMessage>
    {
        public string Name { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
    }
}
