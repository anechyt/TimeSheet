using System.Collections.Generic;

namespace TimeSheet.Domain.Entities
{
    public class Role : BaseEntity
    {
        public Role()
        {
            Activities = new HashSet<Activity>();
        }
        public IReadOnlyCollection<Activity> Activities { get; set; }
    }
}
