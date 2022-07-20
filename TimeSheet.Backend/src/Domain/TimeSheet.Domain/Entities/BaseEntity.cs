using TimeSheet.Domain.ValueObjects;

namespace TimeSheet.Domain.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public Name Name { get; set; }
    }
}
