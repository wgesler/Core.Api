using Core.Domain.Models.Common;

namespace Core.Domain.Models.Sessions
{
    public class Session
    {
        public Identifier Identifier { get; }
        public Identifier ApplicationIdentifier { get; }
        public Identifier UserIdentifier { get; }
        public IEnumerable<SessionDataObject>? Data { get; private set; }
        public DateTime ExpiresUtc { get; }
        public Audit Audit { get; }

        public Session(Identifier identifier, Identifier applicationIdentifier, Identifier userIdentifier, DateTime expiresUtc, Audit audit)
        {
            Identifier = identifier;
            ApplicationIdentifier = applicationIdentifier;
            UserIdentifier = userIdentifier;
            ExpiresUtc = expiresUtc;
            Audit = audit;

            Data = new List<SessionDataObject>().AsReadOnly();
        }

        public void SetData(IEnumerable<SessionDataObject> sessionDataObjects)
        {
            Data = sessionDataObjects;
        }
    }
}
