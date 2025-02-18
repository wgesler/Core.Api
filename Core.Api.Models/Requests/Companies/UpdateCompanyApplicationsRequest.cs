namespace Core.Api.Models.Requests.Companies
{
	public class UpdateCompanyApplicationsRequest
    {
		public List<string> Applications { get; set; } = new List<string>();

		public bool IsValid()
        {
            return Applications.Count >= 0;
        }
    }
}
