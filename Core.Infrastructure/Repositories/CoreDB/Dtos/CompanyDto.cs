
namespace Core.Infrastructure.Repositories.CoreDB.Dtos
{
    public class CompanyDto
    {
        public int CompanyId { get; set; }
        public Guid Guid { get; set; }
        public string? DisplayName { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
