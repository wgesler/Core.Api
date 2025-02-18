
namespace Core.Api.Models.Responses.Companies
{
    public class CompanyResponse
    {
        public Guid Guid { get; set; }
        public string? DisplayName { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public IEnumerable<CompanyAttributeResponse>? CompanyInfo { get; set; }
        public IEnumerable<CompanyApplicationResponse>? CompanyApplications { get; set; }
    }
}
