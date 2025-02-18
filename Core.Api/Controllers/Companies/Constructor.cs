using Core.Api.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace Core.Api.Controllers.Companies
{
    [ApiController]
    [Route("companies")]
    public partial class CompaniesController : BaseController
    {
        public CompaniesController(IHttpContextAccessor hta) : base(hta) {}
    }
}
