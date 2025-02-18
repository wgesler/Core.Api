using Core.Api.Helpers;
using Core.Domain.Interfaces.Repositories;
using Core.Infrastructure.Repositories.CoreDB.Applications;
using Core.Infrastructure.Repositories.CoreDB.Companies;
using Core.Infrastructure.Repositories.CoreDB.Sessions;
using Core.Infrastructure.Repositories.CoreDB.Users;

namespace Core.Infrastructure
{
    public class DataFactory{
        public ICompaniesRepository CompaniesRepository;
        public ISessionsRepository SessionsRepository;
        public IUsersRepository UsersRepository;
        public IApplicationsRepository ApplicationsRepository;

        public DataFactory(AppSettings settings) {
            CompaniesRepository = new CompaniesRepository(settings.DBConnections.Find(o => o.DBName == "coredb")?.ConnectionString);
            SessionsRepository = new SessionsRepository(settings.DBConnections.Find(o => o.DBName == "coredb")?.ConnectionString);
            UsersRepository = new UsersRepository(settings.DBConnections.Find(o => o.DBName == "coredb")?.ConnectionString);
            ApplicationsRepository = new ApplicationsRepository(settings.DBConnections.Find(o => o.DBName == "coredb")?.ConnectionString);
        }
    }
}
