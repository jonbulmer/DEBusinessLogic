using DE.IdentityServer.Settings.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DE.IdentityServer.Settings.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly ValuesSetting _valuesSetting;

        public ValuesController(IOptions<ValuesSetting> valuesSetting)
        {
            _valuesSetting = valuesSetting.Value;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_valuesSetting);
        }

    }
}
