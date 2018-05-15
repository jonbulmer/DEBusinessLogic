using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using DE.IDP.Models;
using DE.IDP.Models.AccountViewModels;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Extensions;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using IdentityServer4.Models;


namespace DE.IDP.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly string a;
        private readonly string b;
        private readonly string c;
        private readonly string d;
        private readonly string e;
        private readonly string f;
        private readonly string g;
        private readonly string h;

        public AccountController(
            UserManger<ApplicationUser> userManger
            )
        {

        }
    }
}
