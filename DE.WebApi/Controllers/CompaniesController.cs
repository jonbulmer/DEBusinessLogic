using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System.Linq;
using DE.WebApi.FakeDataStore;

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
    }   
}
