using DE.WebApi.FakeDataStore;
using DE.WebApi.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DE.WebApi.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetCompanyById()
        {
            // Arrange
            var controller = new CompaniesController(null);
            // Act
            var companyReturned = controller.GetCompany(1);
          

            // Assert
            var testCompany = "{'Id':'1','CompanyName':'Diamond Edge','CompanyDescription':'Host Company','Status':'Mock'}";
            Assert.AreEqual(companyReturned, testCompany);
        }       
    }
}
