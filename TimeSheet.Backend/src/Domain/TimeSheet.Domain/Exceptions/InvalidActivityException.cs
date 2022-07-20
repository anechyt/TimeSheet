using System;

namespace TimeSheet.Domain.Exceptions
{
    public class InvalidActivityException : Exception
    {
        public int Id { get; set; }
        public InvalidActivityException(int id) : base($"Activity: {id} is invalid!")
        {
            Id = id;
        }
    }
}
