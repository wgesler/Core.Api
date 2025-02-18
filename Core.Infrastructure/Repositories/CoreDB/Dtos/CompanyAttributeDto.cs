
namespace Core.Infrastructure.Repositories.CoreDB.Dtos
{
    public class CompanyAttributeDto : AttributeDto
    {
        public int CompanyInfoId { get; set; }
        public int CompanyId { get; set; }
        public string? Value { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }        
    }
}
