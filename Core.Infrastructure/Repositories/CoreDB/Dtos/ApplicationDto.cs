
namespace Core.Infrastructure.Repositories.CoreDB.Dtos
{
    public class ApplicationDto
    {
        public int ApplicationId { get; set; }
        public Guid Guid { get; set; }
        public string? DisplayName { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
