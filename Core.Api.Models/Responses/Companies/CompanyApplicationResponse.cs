
namespace Core.Api.Models.Responses.Companies
{
    public class CompanyApplicationResponse
    {
        public int CompanyApplicationId { get; set; }
        public Guid CompanyGuid { get; set; }
        public Guid ApplicationGuid { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
