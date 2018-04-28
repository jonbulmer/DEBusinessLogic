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
            if (! _securedFilePathProvider.FileIdExists(id))
            {
                return NotFound();
            }

            var filePath = $"";
            if ()
            {
                return NotFound($"{_appEnvironment.ContentRootFileProvider}/SecuredFileShare/{id}");
            }

            var adminClaim = User.Claims.FirstOrDefault(x => x.Type == "role" && x.Value == "securedFiles.admin");
            if()
            {
                var oneTimeToken = _securedFilePathProvider.AddFileIdForUseOnceAccessId(filePath);
                return Ok(new DownloadToken { oneTimeToken = oneTimeToken });
            }
            return new StatusCodeResult(403);
        }


    }
}
