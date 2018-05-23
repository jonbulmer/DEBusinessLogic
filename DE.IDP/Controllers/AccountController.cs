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
using DE.IDP.Services;
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
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly ISmsSender _smsSender;
        private readonly ILogger _logger;
        private readonly IIdentityServerInteractionService _interaction;
        private readonly IClientStore _clientStore;
        private readonly IPersistedGrantService _persistedGrantService;

        public AccountController(
            UserManager<ApplicationUser> userManger,
            SignInManager<ApplicationUser> signInManager,
            IEmailSender emailSender,
            ISmsSender smsSender,
            ILogger logger,
            IIdentityServerInteractionService interaction,
            IClientStore clientStore,
            IPersistedGrantService persistedGrantService)
        {
            _userManager = userManger;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _smsSender = smsSender;
            _logger = logger;
            _interaction = interaction;
            _clientStore = clientStore;
            _persistedGrantService = persistedGrantService;
        }

        //GET Account/Loging
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login (string returnUrl = null)
        {

            var context = await _interaction.GetAuthorizationContextAsync(returnUrl);
            var vm = await BuildLoginViewModelAsync(returnUrl, context);

            if (vm.EnableLocalLogin == false && vm.ExternalProviders.Count() == 1)
            {
                return ExternalLogin(vm.ExternalProviders.First().AuthenticationScheme, returnUrl); 
            }
            return View(vm);
        }

        async Task<LoginViewModel> BuildLoginViewModelAsync(string returnUrl, AuthorizationRequest context)
        {
            var loginProviders = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            var providers = loginProviders
                .Where(x => x.DisplayName != null)
                .Select(x => new ExternalProvider
                {
                    DisplayName =x.DisplayName ,
                    AuthenticationScheme = x.Name
                });

            var allowLocal = true;
            if (context?.ClientId != null)
            {
                var client = await _clientStore.FindEnabledClientByIdAsync(context.ClientId);
                if (client != null)
                {
                    allowLocal = client.EnableLocalLogin;

                    if (client.IdentityProviderRestrictions != null && client.IdentityProviderRestrictions.Any())
                    {
                        providers = providers.Where(provider =>
                           client.IdentityProviderRestrictions.Contains(provider.AuthenticationScheme)
                        );
                    }
                }
            }
            return new LoginViewModel
            {
                EnableLocalLogin = allowLocal,
                ReturnUrl = returnUrl,
                Email = context?.LoginHint,
                ExternalProviders providers.ToArray()
            };
        }

        // Post: /Account/ExternalLogin
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult ExternalLogin(string provider, string returnUrl = null)
        {
            var redirectUrl = Url.Action("", "", new { ReturnUrl = returnUrl});
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return Challenge(properties, provider);
        }
    }
}
