using System.Text.Json;
using Core.Api.Helpers.Sessions;
using Core.Api.Models.Requests.Sessions;
using Core.Api.Models.Responses.Sessions;
using FourT.Shared.Utilities.MicroServices.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Core.Api.Controllers.Session
{
    public partial class SessionController
    {
        [AcceptVerbs(new[] { "PATCH" })]
        [Route("{id:guid}")]
        public async Task<SessionResponse> UpdateSession(Guid id, [FromBody] IEnumerable<SessionDataObjectRequest> sessionData)
        {
            var session = await Data.SessionsRepository.GetSessionByGuid(id);

            if (session == null || session.Identifier.Id <= 0)
            {
                throw new Exception("Error: Invalid Session");
            }

            return SessionHelper.ConvertSessionToSessionResponse(
                await Data.SessionsRepository.UpdateSession(
                    session.Identifier.Id, JsonSerializer.Serialize(SessionHelper.ConvertSessionDataObjectRequestsToSessionDataObjects(sessionData)
                    ), 1));
        }

        [AcceptVerbs(new[] { "PATCH" })]
        [Route("{id:guid}/expire")]
        public async Task<bool> ExpireSession(Guid id)
        {
            var resp = await Data.SessionsRepository.ExpireSession(id);
            return resp;
        }
    }
}