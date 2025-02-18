using Core.SDK.Interfaces;
using Core.SDK.Services;

namespace Core.SDK
{
    public class FourTCoreClient : IFourTCoreClient
    {
        public IApplicationsService Applications { get; set; }
        public ICompaniesService Companies { get; set; }
        public IUsersService Users { get; set; }
        public ISessionsService Sessions { get; set; }
        public FourTCoreClient(string baseUrl)
        {
            Companies = new CompaniesService(baseUrl);
            Users = new UsersService(baseUrl);
            Sessions = new SessionsService(baseUrl);
            Applications = new ApplicationsService(baseUrl);
        }
    }
}
