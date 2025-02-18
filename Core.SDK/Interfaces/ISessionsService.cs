using Core.Api.Models.Requests.Sessions;
using Core.Api.Models.Responses.Sessions;

namespace Core.SDK.Interfaces
{
    public interface ISessionsService
    {
        Task<SdkResponse<SessionResponse>> GetSession(Guid sessionGuid);
        Task<SdkResponse<SessionResponse>> UpdateSession(Guid sessionGuid, IEnumerable<SessionDataObjectRequest> sessionData);
        Task<SdkResponse<bool>> ExpireSession(Guid sessionGuid);
        Task<SdkResponse<bool>> DeleteSession(Guid sessionGuid);
    }
}
