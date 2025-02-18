using Core.Api.Models.Requests.Sessions;
using Core.Api.Models.Responses.Sessions;
using Core.SDK.Interfaces;
using FourT.Shared.Utilities.MicroServices.Abstracts;
using RestSharp;

namespace Core.SDK.Services
{
    public class SessionsService : BaseService, ISessionsService
    {
        public SessionsService(string baseUrl) : base(baseUrl) { }

        public async Task<SdkResponse<SessionResponse>> GetSession(Guid sessionGuid)
        {
            return await ExecuteRequest<SdkResponse<SessionResponse>, SessionResponse>($"/sessions/{sessionGuid}",
                Method.Get);
        }

        public async Task<SdkResponse<SessionResponse>> UpdateSession(Guid sessionGuid,
            IEnumerable<SessionDataObjectRequest> sessionData)
        {
            return await ExecuteRequest<SdkResponse<SessionResponse>, SessionResponse>($"/sessions/{sessionGuid}",
                Method.Patch, sessionData);
        }

        public async Task<SdkResponse<bool>> ExpireSession(Guid sessionGuid)
        {
            return await ExecuteRequest<SdkResponse<bool>, bool>($"/sessions/{sessionGuid}/expire", Method.Patch);
        }

        public async Task<SdkResponse<bool>> DeleteSession(Guid sessionGuid)
        {
            return await ExecuteRequest<SdkResponse<bool>, bool>($"/sessions/" + sessionGuid.ToString(), Method.Delete);
        }
    }
}
