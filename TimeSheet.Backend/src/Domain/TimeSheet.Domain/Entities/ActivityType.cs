using System.Collections.Generic;

namespace TimeSheet.Domain.Entities
{
    public class ActivityType : BaseEntity
    {
        public ActivityType()
        {
            Activities = new HashSet<Activity>();
        }
        public IReadOnlyCollection<Activity> Activities { get; set; }
    }
}
