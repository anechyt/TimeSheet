using System;

namespace TimeSheet.Domain.Exceptions
{
    public class InvalidActivityTypeException : Exception
    {
        public int Id { get; set; }
        public InvalidActivityTypeException(int id) : base($"ActivityType: {id} is invalid!")
        {
            Id = id;
        }
    }
}
