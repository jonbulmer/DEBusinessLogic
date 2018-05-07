using System.Linq;
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
                return new FileContentResult(fileContents, "application/octet-stream");
            }
            return new StatusCodeResult(401);
        }

        [Authorize]
        [HttpGet("GenerateOneTimeAccessToken/{id}")]
        public IActionResult GenorateOneTimeAccessToken(string  id)
        {
            if (! _securedFilePathProvider.FileIdExists(id))
            {
                return NotFound($"File id dose not exitst: {id}");
            }

            var filePath = $"{_appEnvironment.ContentRootPath}/SecuredFileShare/{id}";
            if (!System.IO.File.Exists(filePath))
            {
                return NotFound($"File id dose not exitst: {id}");
            }

            var adminClaim = User.Claims.FirstOrDefault(x => x.Type == "role" && x.Value == "securedFiles.admin");
            if(_securedFilePathProvider.HasUserClaimToAccessFile(id, adminClaim != null))
            {
                var oneTimeToken = _securedFilePathProvider.AddFileIdForUseOnceAccessId(filePath);
                return Ok(new DownloadToken { oneTimeToken = oneTimeToken });
            }
            return new StatusCodeResult(403);
        }


    }
}
