using System.Text.Json;
using Core.Domain.Interfaces.Repositories;
using Core.Domain.Models.Sessions;
using Core.Infrastructure.Repositories.CoreDB.Dtos;
using Core.Domain.Models.Common;

namespace Core.Infrastructure.Repositories.CoreDB.Sessions
{
    public partial class SessionsRepository : SQLRepository, ISessionsRepository
    {
        public SessionsRepository(string con) : base(con) { }       

        private static Session? ConvertDtoToModel(SessionDto? sessionDto)
        {
            if (sessionDto == null) { return null; }

            var session = new Session(new Identifier(sessionDto.SessionId, sessionDto.Guid),
                new Identifier(sessionDto.ApplicationId, sessionDto.ApplicationGuid),
                new Identifier(sessionDto.UserId, sessionDto.UserGuid), sessionDto.ExpiresUtc,
                new Audit(sessionDto.CreatedBy, sessionDto.CreatedOn, sessionDto.ModifiedBy, sessionDto.ModifiedOn));

            session.SetData(JsonSerializer.Deserialize<List<SessionDataObject>>(sessionDto.SessionData));

            return session;
        }
    }
}
