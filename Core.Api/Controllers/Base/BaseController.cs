using Core.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Core.Api.Controllers.Base
{
    [ApiController]
    public abstract class BaseController 
    {
        protected DataFactory Data;
        public BaseController(IHttpContextAccessor hta)
        {
            Data = new DataFactory(SETTINGS);
        }
    }
}
