using Core.Api.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace Core.Api.Controllers.Users
{
    [ApiController]
    [Route("users")]
    public partial class UsersController : BaseController
    {
        public UsersController(IHttpContextAccessor hta) : base(hta) {}
    }
}
