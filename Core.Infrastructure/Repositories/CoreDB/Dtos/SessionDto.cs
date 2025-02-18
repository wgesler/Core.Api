
namespace Core.Infrastructure.Repositories.CoreDB.Dtos
{
    public class SessionDto
    {
        public int SessionId { get; set; }
        public Guid Guid { get; set; }
        public int ApplicationId { get; set; }
        public Guid ApplicationGuid { get; set; }
        public int UserId { get; set; }
        public Guid UserGuid { get; set; }
        public string? SessionData { get; set; }
        public DateTime ExpiresUtc { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
