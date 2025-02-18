
namespace Core.Api.Models.Responses.Applications
{
    public class ApplicationResponse
    {
        public Guid Guid { get; set; }
        public string? DisplayName { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
