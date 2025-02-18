using Microsoft.AspNetCore.Mvc;

namespace Core.Api.Controllers.Session
{
	public partial class SessionController
    {
        [AcceptVerbs(new[] { "DELETE" })]
        [Route("{id}")]
        public async Task<bool> DeleteSession(Guid id)
        {
            var session = await Data.SessionsRepository.GetSessionByGuid(id);

            if (session == null)
            {
                throw new Exception("Error: Invalid Session");
            }

            return await Data.SessionsRepository.DeleteSession(id);
        }
    }
}
