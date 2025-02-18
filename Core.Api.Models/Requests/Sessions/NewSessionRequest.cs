
namespace Core.Api.Models.Requests.Sessions
{
    public class NewSessionRequest
    {
        public Guid ApplicationGuid { get; set; }
        public Guid UserId { get; set; }
        public IEnumerable<SessionDataObjectRequest>? Data { get; set; }
        public int CreatedBy { get; set; }
    }
}
