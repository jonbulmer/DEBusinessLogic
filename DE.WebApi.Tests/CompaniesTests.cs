using DE.WebApi.FakeDataStore;
using DE.WebApi.Controllers;
//using NSubstitute;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace DE.WebApi.Tests
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
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
