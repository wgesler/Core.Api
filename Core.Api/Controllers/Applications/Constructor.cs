using Core.Api.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace Core.Api.Controllers.Applications
{
    [ApiController]
    [Route("applications")]
    public partial class ApplicationsController : BaseController
    {
        public ApplicationsController(IHttpContextAccessor hta) : base(hta) {}
    }
}
