using System;

namespace TimeSheet.Domain.Exceptions
{
    public class InvalidEmployeeException : Exception
    {
        public int Id { get; set; }
        public InvalidEmployeeException(int id) : base($"Employee {id} is invalid!")
        {
            Id = id;
        }
    }
}
