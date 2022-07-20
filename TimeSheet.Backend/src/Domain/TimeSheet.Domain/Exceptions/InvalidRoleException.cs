using System;

namespace TimeSheet.Domain.Exceptions
{
    public class InvalidRoleException : Exception
    {
        public int Id { get; set; }
        public InvalidRoleException(int id) : base($"Role: {id} is invalid!")
        {
            Id = id;
        }
    }
}
