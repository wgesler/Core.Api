
namespace Core.Domain.Models.Sessions
{
    public class SessionDataObject
    {
        public string Name { get; }
        public object Value { get; }

        public SessionDataObject(string name, object value)
        {
            Name = name;
            Value = value;
        }
    }
}
