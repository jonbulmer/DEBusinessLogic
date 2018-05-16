using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly UserManager<ApplicationUser> _userManger;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly ISmsSender _smsSender;
        private readonly ILogger _logger;
        private readonly IIdentityServerInteractionService _interaction;
        private readonly IClientStore _clientStore;
        private readonly IPersistedGrantService _persistedGrantService;

        public AccountController(
            UserManager<ApplicationUser> userManger,
            SignInManager<ApplicationUser> _signInManager,
            IEmailSender _emailSender,
            ISmsSender _smsSender,
            ILogger _logger,
            IIdentityServerInteractionService _interaction,
            IClientStore _clientStore,
            IPersistedGrantService _persistedGrantService)
        {
            _userManger
        _signInManager = _signInManager;
        _emailSender;
        _smsSender;
        _logger;
        _interaction;
        _clientStore;
        _persistedGrantService
        }
    }
}
