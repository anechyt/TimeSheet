using System;
using System.Collections.Generic;
using TimeSheet.Domain.ValueObjects;

namespace TimeSheet.Domain.Entities
{
    public class Employee
    {
        public Employee()
        {
            Activities = new HashSet<Activity>();
        }
        public int Id { get; set; }
        public Name Name { get; set; }
        public Sex Sex { get; set; }
        public DateTime Birthday { get; set; }

        public IReadOnlyCollection<Activity> Activities { get; set; }
    }
}
