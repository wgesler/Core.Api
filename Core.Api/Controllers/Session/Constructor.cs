using Core.Api.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace Core.Api.Controllers.Session
{   
    [ApiController]
    [Route("sessions")]
    public partial class SessionController : BaseController
    {
        public SessionController(IHttpContextAccessor hta) : base(hta) { }
    }
}
