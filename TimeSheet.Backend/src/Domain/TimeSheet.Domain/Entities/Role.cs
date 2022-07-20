using System.Collections.Generic;
using TimeSheet.Domain.ValueObjects;

namespace TimeSheet.Domain.Entities
{
    public class Role
    {
        public Role()
        {
            Activities = new HashSet<Activity>();
        }
        public int Id { get; set; }
        public Name Name { get; set; }
        public IReadOnlyCollection<Activity> Activities { get; set; }
    }
}
