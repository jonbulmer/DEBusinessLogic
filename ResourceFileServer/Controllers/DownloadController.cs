using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ResourceFileServer.Providers;
using Microsoft.AspNetCore.Hosting;

namespace ResourceFileServer.Controllers
{
    [Route("api/[controller]")]
    public class DownloadController : Controller
    {
        public DownloadController()
        {

        }

        [AllowAnonymous]
        [HttpGet("{accessId}/{id}")]
        public IActionResult Get()
        {

        }


        public IActionResult GenorateOneTimeAccessToken()
        {

        }


    }
}
