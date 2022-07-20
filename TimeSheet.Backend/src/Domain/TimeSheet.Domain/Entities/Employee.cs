using System;
using TimeSheet.Domain.ValueObjects;

namespace TimeSheet.Domain.Entities
{
    public class Employee : BaseEntity
    {
        public Sex Sex { get; set; }
        public DateTime Birthday { get; set; }
    }
}
