using System;

namespace TimeSheet.Application.Dto
{
    public class CreateProjectDto
    {
        public string Name { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
    }
}
