using System;

namespace TimeSheet.Domain.Exceptions
{
    public class InvalidSexException : Exception
    {
        public string Sex { get; set; }
        public InvalidSexException(string sex) : base($"Sex:  {sex} is invalid!")
        {
            Sex = sex;
        }
    }
}
