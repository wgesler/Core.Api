
namespace Core.Infrastructure.Repositories.CoreDB.Dtos
{
    public class CompanyApplicationDto
    {
        public int CompanyApplicationId { get; set; }
        public int CompanyId { get; set; }
        public Guid CompanyGuid { get; set; }
        public int ApplicationId { get; set; }
        public Guid ApplicationGuid { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? DisplayName { get; set; }
    }
}
