using System;
using System.Collections.Generic;

namespace TimeSheet.Domain.Entities
{
    public class Project : BaseEntity
    {
        public Project()
        {
            Activities = new HashSet<Activity>();
        }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }

        public IReadOnlyCollection<Activity> Activities { get; set; }
    }
}
