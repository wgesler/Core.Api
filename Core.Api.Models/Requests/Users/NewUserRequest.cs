
using Core.Api.Models.Requests.Common;

namespace Core.Api.Models.Requests.Users
{
    public class NewUserRequest
    {
        public string? EmailAddress { get; set; }
        public string? Password { get; set; }
        public Guid AppId { get; set; }
        public Guid CompanyId { get; set; }
        public IEnumerable<AttributeRequest>? Info { get; set; }

        public bool IsValid()
        {
            if (!IsValidEmail()) { return false; }

            return !string.IsNullOrEmpty(Password) && ValidAttributes();
        }

        public bool IsValidEmail()
        {
            if (string.IsNullOrEmpty(EmailAddress) || string.IsNullOrWhiteSpace(EmailAddress)) { return false; }
            return EmailAddress.Contains('@') && EmailAddress.Contains('.');
        }

        public string InvalidMessage()
        {
            var msg = "";
            if (!IsValidEmail()) { msg += "Invalid Email;"; }
            if (string.IsNullOrEmpty(Password)) { msg += "Invalid Password;"; }
            return msg;
        }

        public bool ValidAttributes()
        {
            return Info?.ToList().Find(o => !o.IsValid()) == null;
        }
    }
}
