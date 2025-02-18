using Core.Api.Helpers.Sessions;
using Core.Api.Models.Responses.Sessions;
using Microsoft.AspNetCore.Mvc;

namespace Core.Api.Controllers.Session
{   
    public partial class SessionController
    {
        [AcceptVerbs(new[] { "GET" })]
        [Route("{id}")]
        public async Task<SessionResponse> GetSessionById(Guid id)
        {
            return SessionHelper.ConvertSessionToSessionResponse(await Data.SessionsRepository.GetSessionByGuid(id));
        }
    }
}
