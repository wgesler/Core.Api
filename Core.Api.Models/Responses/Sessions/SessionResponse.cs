
namespace Core.Api.Models.Responses.Sessions
{
    public class SessionResponse
    {
        public Guid Guid { get; set; }
        public IEnumerable<SessionDataObjectResponse>? Data { get; set; }
    }
}
