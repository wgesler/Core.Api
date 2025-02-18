using Core.Domain.Models.Applications;
using Core.Domain.Models.Companies;
using Core.Infrastructure.Repositories.CoreDB.Dtos;
using FourT.Shared.Utilities.Extensions;
using System.Data.SqlClient;

namespace Core.Infrastructure.Repositories.CoreDB.Companies
{
    public partial class CompaniesRepository
    {
        public async Task<Company?> GetCompanyById(int id)
        {
            using (var db = new SqlConnection(_dbConnectionString))
            {
                var ret = await db.DapperProcQueryAsync<CompanyDto>("dbo.Companies_GetById", new { Id = id });

                return await CreateCompleteCompany(ret.FirstOrDefault());
            }
        }

        public async Task<Company?> GetCompanyByName(string displayName)
        {
            using (var db = new SqlConnection(_dbConnectionString))
            {
                var ret = await db.DapperProcQueryAsync<CompanyDto>("dbo.Companies_GetByName",
                    new { DisplayName = displayName });

                return await CreateCompleteCompany(ret.FirstOrDefault());
            }
        }

        public async Task<Company?> GetCompanyByGuid(Guid guid)
        {
            using (var db = new SqlConnection(_dbConnectionString))
            {
                var ret = await db.DapperProcQueryAsync<CompanyDto>("dbo.Companies_GetByGUID", new { GUID = guid });

                return await CreateCompleteCompany(ret.FirstOrDefault());
            }
        }

        public async Task<IEnumerable<Company>> GetCompaniesWhereAttributeExists(string attributeName)
        {
            using (var db = new SqlConnection(_dbConnectionString))
            {
                var companies = new List<Company>();
                var ret = await db.DapperProcQueryAsync<CompanyDto>("dbo.Companies_GetWhereAttributeExists",
                    new { AttributeName = attributeName });

                foreach (var ctd in ret)
                {
                    companies.Add(await CreateCompleteCompany(ctd));
                }

                return companies;
            }
        }

        public async Task<IEnumerable<CompanyAttribute>> GetCompanyAttributesByCompanyId(int id)
        {
            using (var db = new SqlConnection(_dbConnectionString))
            {
                var ret = await db.DapperProcQueryAsync<CompanyAttributeDto>("dbo.Companies_GetAttributesByCompanyId",
                    new { CompanyId = id });

                return ConvertDtoToModel(ret);
            }
        }

        public async Task<CompanyAttribute> GetCompanyAttributeByCompanyInfoId(int id)
        {
            using (var db = new SqlConnection(_dbConnectionString))
            {
                var ret = await db.DapperProcQueryAsync<CompanyAttributeDto>(
                    "dbo.Companies_GetCompanyAttributeByCompanyInfoId", new { CompanyInfoId = id });

                return ConvertDtoToModel(ret.FirstOrDefault());
            }
        }

        public async Task<CompanyApplication?> GetCompanyApplicationById(int companyApplicationId)
        {
            using (var db = new SqlConnection(_dbConnectionString))
            {
                var ret = await db.DapperProcQueryAsync<CompanyApplicationDto>(
                    "dbo.Companies_GetCompanyApplicationById", new { CompanyApplicationId = companyApplicationId });

                return ConvertDtoToModel(ret.FirstOrDefault());
            }
        }

        public async Task<IEnumerable<CompanyApplication>?> GetCompanyApplicationsByCompanyId(int companyId)
        {
            using (var db = new SqlConnection(_dbConnectionString))
            {
                var ret = await db.DapperProcQueryAsync<CompanyApplicationDto>(
                    "dbo.Companies_GetCompanyApplicationsByCompanyId", new { CompanyId = companyId });

                return ConvertDtoToModel(ret);
            }
        }

        public async Task<List<string?>> GetCompanyApplicationListByCompanyGuid(Guid companyGuid)
        {
            using (var db = new SqlConnection(_dbConnectionString))
            {
                var ret = await db.DapperProcQueryAsync<CompanyApplicationDto>(
                    "dbo.Companies_GetApplicationsByCompanyGUID", new { CompanyGUID = companyGuid });

                return ret.Select(app => app.DisplayName?.ToUpper()).ToList();
            }
        }

        private async Task<Company?> CreateCompleteCompany(CompanyDto? companyDto)
        {
            var company = ConvertDtoToModel(companyDto);
            company?.SetCompanyInfo(await GetCompanyAttributesByCompanyId(company.Identifier.Id));
            company?.SetCompanyApplications(await GetCompanyApplicationsByCompanyId(company.Identifier.Id));

            return company;
        }
    }
}
