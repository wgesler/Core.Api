
namespace Core.Infrastructure.Repositories.CoreDB.Dtos
{
    public class UserAttributeDto : AttributeDto
    {
        public int UserInfoId { get; set; }
        public int UserId { get; set; }
        public string? Value { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
    }
}
