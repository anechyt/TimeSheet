using System;

namespace TimeSheet.Application.Dto
{
    public class CreateEmployeeDto
    {
        public string Name { get; set; }
        public string Sex { get; set; }
        public DateTime Birthday { get; set; }
    }
}
