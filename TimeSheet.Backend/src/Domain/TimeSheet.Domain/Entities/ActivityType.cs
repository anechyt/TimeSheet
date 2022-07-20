using System.Collections.Generic;
using TimeSheet.Domain.ValueObjects;

namespace TimeSheet.Domain.Entities
{
    public class ActivityType
    {
        public ActivityType()
        {
            Activities = new HashSet<Activity>();
        }
        public int Id { get; set; }
        public Name Name { get; set; }
        public IReadOnlyCollection<Activity> Activities { get; set; }
    }
}
