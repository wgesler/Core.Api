
namespace Core.Api.Models.Requests.Common
{
    public class AttributeRequest
    {
        public string? AttributeName { get; set; }
        public string? AttributeValue { get; set; }

        public bool IsValid()
        {
            return IsValidAttributeName() && !string.IsNullOrEmpty(AttributeValue);
        }
        public bool IsValidAttributeName()
        {
            return !string.IsNullOrEmpty(AttributeName) && !string.IsNullOrWhiteSpace(AttributeName) && !AttributeName.Contains(' ');
        }
    }
}
