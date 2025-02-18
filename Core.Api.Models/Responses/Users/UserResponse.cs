
namespace Core.Api.Models.Responses.Users
{
    public class UserResponse
    {
        public Guid Guid { get; set; }
        public string? EmailAddress { get; set; }
        public bool IsActive { get; set; }
		public bool IsLocked { get; set; }
		public int FailedLoginAttempts { get; set; }
		public Guid CompanyId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public IEnumerable<UserAttributeResponse>? UserInfo { get; set; }
    }
}
