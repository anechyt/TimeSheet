using TimeSheet.Domain.Exceptions;

namespace TimeSheet.Domain.ValueObjects
{
    public class Sex
    {
        public string Value { get; set; }
        public Sex(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new InvalidSexException(value);
            if (value.Length > 36 || value.Length < 3)
                throw new InvalidSexException(value);

            Value = value;
        }

        public static implicit operator Sex(string value) => value is null ? null : new Sex(value);
        public static implicit operator string(Sex value) => value.Value;
        public override string ToString() => Value;
    }
}
