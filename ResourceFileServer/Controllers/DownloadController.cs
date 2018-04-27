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
        private readonly IHostingEnvironment _appEnvironment;
        private readonly ISecuredFileProvider _securedFilePathProvider;
        public DownloadController(ISecuredFileProvider securedFileProvider, IHostingEnvironment appEnvironment)
        {
            _securedFilePathProvider = securedFileProvider;
            _appEnvironment = appEnvironment;
        }

        [AllowAnonymous]
        [HttpGet("{accessId}/{id}")]
        public IActionResult Get(string accessId, string id)
        {
            var filePath = _securedFilePathProvider.GetFileIdForUseOnceAccessId(accessId);
            if(!string.IsNullOrEmpty(filePath))
            {
                var fileContents = System.IO.File.ReadAllBytes(filePath);
                return new FileContentResult(fileContents, 'application/octet-stream');
            }
            return new StatusCodeResult(401);
        }


        public IActionResult GenorateOneTimeAccessToken(string  id)
        {

        }


    }
}
