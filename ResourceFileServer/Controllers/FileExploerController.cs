using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ResourceFileServer.Providers;

namespace ResourceFileServer.Controllers
{
    public class FileExploerController : Controller
    {
        public FileExploerController()
        {

        }

        public IActionResult Get()
        {
            // TODO MUST FIX. rc4 update does not work. claims are missing
            var adminClaim
            var files = 
            return Ok(files); 
        }
    }
}
