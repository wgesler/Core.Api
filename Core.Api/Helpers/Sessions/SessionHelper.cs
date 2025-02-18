using Core.Api.Models.Requests.Sessions;
using Core.Api.Models.Responses.Sessions;
using Core.Domain.Models.Sessions;
using FourT.Shared.Utilities.MicroServices.Exceptions;

namespace Core.Api.Helpers.Sessions
{
    public class SessionHelper
    {
        public static SessionResponse ConvertSessionToSessionResponse(Session session)
        {
            if (session == null)
            {
                throw new AppException("Invalid Session");
            }
            return new SessionResponse()
            {
                Guid = session.Identifier.Guid,
                Data = session.Data.Select(ConvertSessionDataObjectToSessionDataObjectResponse)
            };
        }

        public static SessionDataObjectResponse ConvertSessionDataObjectToSessionDataObjectResponse(SessionDataObject sessionDataObject)
        {
            return new SessionDataObjectResponse() { Name = sessionDataObject.Name, Value = sessionDataObject.Value };
        }

        public static IEnumerable<SessionDataObject> ConvertSessionDataObjectRequestsToSessionDataObjects(
            IEnumerable<SessionDataObjectRequest> sessionDataObjectRequests)
        {
            return sessionDataObjectRequests.Select(ConvertSessionDataObjectRequestToSessionDataObject).ToList();
        }

        public static SessionDataObject ConvertSessionDataObjectRequestToSessionDataObject(
            SessionDataObjectRequest sessionDataObjectRequest)
        {
            return new SessionDataObject(sessionDataObjectRequest.Name, sessionDataObjectRequest.Value);
        }
    }
}
