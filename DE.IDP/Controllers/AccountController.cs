using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DE.IDP.Models;

namespace DE.IDP.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        public AccountController(
            UserManger<Application> userManger
            )
        {

        }
    }
}
