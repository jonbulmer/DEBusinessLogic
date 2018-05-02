using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ResourceFileServer.Providers;

namespace ResourceFileServer.Controllers
{
    [Authorize("securedFiles")]
    [Route("api/[controler]")]
    public class FileExploerController : Controller
    {
        private readonly ISecuredFileProvider _securedFileProvider;


        public FileExploerController(ISecuredFileProvider securedFileProvider)
        {
            _securedFileProvider = securedFileProvider;
        }

        [HttpGet]
        public IActionResult Get()
        {
            // TODO MUST FIX. rc4 update does not work. claims are missing
            var adminClaim = User.Claims.FirstOrDefault(x => x.Type == "role" && x.Value == "secured.admin");
            var files = _securedFileProvider.GetFileIdForUser(adminClaim != null);

            return Ok(files); 
        }
    }
}
