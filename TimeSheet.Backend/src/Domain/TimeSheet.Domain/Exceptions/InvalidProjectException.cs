using System;

namespace TimeSheet.Domain.Exceptions
{
    public class InvalidProjectException : Exception
    {
        public int Id { get; set; }
        public InvalidProjectException(int id) : base($"Project: {id} is invalid!")
        {
            Id = id;
        }
    }
}
