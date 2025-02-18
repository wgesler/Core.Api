namespace Core.SDK.Interfaces
{
    public interface IFourTCoreClient 
    {
        public IApplicationsService Applications { get; set; }
        public ICompaniesService Companies { get; set; }
        public IUsersService Users { get; set; }
        public ISessionsService Sessions { get; set; }
    }
}
