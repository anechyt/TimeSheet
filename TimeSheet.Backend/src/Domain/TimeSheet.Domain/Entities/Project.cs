using System;
using System.Collections.Generic;
using TimeSheet.Domain.ValueObjects;

namespace TimeSheet.Domain.Entities
{
    public class Project 
    {
        public Project()
        {
            Activities = new HashSet<Activity>();
        }
        public int Id { get; set; }
        public Name Name { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }

        public IReadOnlyCollection<Activity> Activities { get; set; }
    }
}
