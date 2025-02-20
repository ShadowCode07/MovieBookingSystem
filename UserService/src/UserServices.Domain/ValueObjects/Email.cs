using System.Text.RegularExpressions;

namespace UserService.src.UserServices.Domain.ValueObjects
{
    public class Email
    {
        public string Value { get; set; }

        private static readonly Regex EmialRegex =
            new(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled);

        public Email(string value)
        {
            if (string.IsNullOrEmpty(value) || !EmialRegex.IsMatch(value))
            {
                throw new ArgumentException("Invalid emial format");
            }

            Value = value;
        }

        public static Email Create(string email)
        {
            return new Email(email);
        }

        public static implicit operator string(Email email) => email.Value;

        public override string ToString() => Value;
    }
}
