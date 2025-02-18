
namespace Core.Infrastructure.Repositories.CoreDB.Dtos
{
    public class UserDto
    {
        public int UserId { get; set; }
        public Guid Guid { get; set; }
        public string? EmailAddress { get; set; }
        public byte[]? Hash { get; set; }
        public byte[]? Salt { get; set; }
        public bool IsActive { get; set; }
		public bool IsLocked { get; set; }
		public int FailedLoginAttempts { get; set; }
        public int CompanyId { get; set; }
        public Guid CompanyGuid { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        
    }
}
