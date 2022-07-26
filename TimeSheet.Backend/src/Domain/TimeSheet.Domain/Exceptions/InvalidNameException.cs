﻿using System;

namespace TimeSheet.Domain.Exceptions
{
    public class InvalidNameException : Exception
    {
        public string Name { get; set; }
        public InvalidNameException(string name) : base($"Name: {name} is invalid!")
        {
            Name = name;
        }
    }
}
