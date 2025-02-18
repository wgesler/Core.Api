using Core.Domain.Models.Common;

namespace Core.Domain.Models.Applications
{
    public class Application
    {
        public Identifier Identifier { get; }
        public string DisplayName { get; }
        public Audit Audit { get; }

        public Application(Identifier identifier, string displayName, Audit audit)
        {
            Identifier = identifier;
            DisplayName = displayName;
            Audit = audit;
        }
    }
}
