
using Core.Api.Models.Requests.Common;

namespace Core.Api.Models.Requests.Companies
{
    public class NewCompanyRequest
    {
        public string? DisplayName { get; set; }
        public Guid ApplicationGuid { get; set; }
        public IEnumerable<AttributeRequest>? Info { get; set; }

        public bool IsValid()
        {
            return ValidAttributes() && !string.IsNullOrEmpty(DisplayName) && ApplicationGuid != default;
        }
        
        public bool ValidAttributes()
        {
            return Info?.ToList().Find(o => !o.IsValid()) == null;
        }
    }

    
}
