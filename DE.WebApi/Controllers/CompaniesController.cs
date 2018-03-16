using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System.Linq;
using DE.WebApi.FakeDataStore;
using DE.WebApi.Models;

namespace DE.WebApi.Controllers
{
    [Route("api/companies")]
    public class CompaniesController : Controller
    {
        private ILogger<CompaniesController> _logger;

        public CompaniesController(ILogger<CompaniesController> logger)
        {
            _logger = logger;
        }

        [HttpGet()]
        public IActionResult GetCompanies()
        {
            return Ok(CompaniesDataStore.Current.Companies);
        }

        [HttpGet("{id}", Name = "Get Company")]
        public IActionResult GetCompany(int id)
        {
            var companyToReturn = CompaniesDataStore.Current.Companies.FirstOrDefault(c => c.Id == id);
            if (companyToReturn == null)
            {
                _logger.LogInformation($"Company with id {id} as not found");
                return NotFound();
            }
            return Ok(companyToReturn);
        }

        [HttpPost()]
        public IActionResult CreateCompany([FromBody] CompanyForCreationDto Company)
        {
            if (Company == null)
            {
                return BadRequest();
            }

            var finalCompany = new CompanyDto()
            {
                Id = 3,
                CompanyName = Company.Company,
                CompanyDescription = Company.Company,
                Status = Company.Company
            };
            CompaniesDataStore.Current.Companies.Add(finalCompany);

            return CreatedAtRoute("GetCompany",new { id = 3}, finalCompany );
        }
    }   
}
