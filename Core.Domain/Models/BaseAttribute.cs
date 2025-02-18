using Core.Domain.Models.Common;

namespace Core.Domain.Models
{
    public abstract class BaseAttribute
    {
        public int AttributeId { get; }
        public string? AttributeName { get; }

        public BaseAttribute(int attributeId, string attributeName)
        {
            AttributeId = attributeId;
            AttributeName = attributeName;
        }

        public BaseAttribute(string attributeName)
        {
            AttributeName = attributeName;
        }
    }
}
