using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DE.WebApi.Models;
using DE.WebApi.Models.ManageViewModels;
using DE.IDP.;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http.Authentication;

namespace DE.IDP.Controllers
{
    [Authorize]
    public class ManageController : Controller
    {
        public ManageController()
        {
            private readonly UserManager<ApplicationUser> userManager;
            private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
            private readonly
            private readonly
            UserManager<ApplicationUser> userManager;
        }
    }
}
