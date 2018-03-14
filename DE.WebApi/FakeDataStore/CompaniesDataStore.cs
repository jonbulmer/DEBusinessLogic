using DE.WebApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DE.WebApi.FakeDataStore
{
    public class CompaniesDataStore
    {
        public static CompaniesDataStore Current { get; }  = new CompaniesDataStore();
        public List<CompanyDto> Companies { get; set; }

        public CompaniesDataStore()
        {
            Companies = new List<CompanyDto>()
            {
                new CompanyDto
                {
                    Id = 1,
                    CompanyName = "Diamond Edge",
                    CompanyDescription = "Host Company",
                    Status = "Mock"
                }
            };
        }
    }
}
