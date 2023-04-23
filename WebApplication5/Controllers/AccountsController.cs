using WebApplication5.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.EntityFrameworkCore;
using WebApplication5.Data;

namespace WebApplication5.Server.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository accountRepository;
        private readonly WebApplication5Context _webApplication5Context;

        public AccountController(IAccountRepository accountRepository, WebApplication5Context webApplication5Context)
        {
            this.accountRepository = accountRepository;
            _webApplication5Context = webApplication5Context;
        }

        //public IEnumerable<UserClaim> GetUserClaims()
        //{
        //    foreach (var claim in User.Claims)
        //        yield return new UserClaim
        //        {
        //            Type = claim.Type,
        //            Value = claim.Value
        //        };
        //}

        public IActionResult Login(string returnUrl = "/")
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(new LoginModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var account = accountRepository.GetAccountWithUsernameAndPassword(model.Username, model.Password);
            if (account == null)
                return Unauthorized();

            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, account.AccountId.ToString()),
            new Claim(ClaimTypes.Name, account.Name),
            new Claim(ClaimTypes.Role, account.Role.ToString()),
        };

            var identity = new ClaimsIdentity(claims,
                CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                principal,
                new AuthenticationProperties { IsPersistent = model.RememberLogin });

            return LocalRedirect(model.ReturnUrl);
        }

        public IActionResult LoginWithGoogle(string returnUrl = "/")
        {
            var props = new AuthenticationProperties
            {
                RedirectUri = Url.Action("GoogleLoginCallback"),
                Items =
                {
                    { "ReturnUrl", returnUrl }
                }
            };
            return Challenge(props, GoogleDefaults.AuthenticationScheme);
        }

        public async Task<IActionResult> GoogleLoginCallback()
        {
            // Get identity from google's cookie
            var result = await HttpContext.AuthenticateAsync(GoogleDefaults.AuthenticationScheme);
            if (result.Principal == null)
                throw new Exception("Could not create a principal");
            var externalClaims = result.Principal.Claims.ToList();
            var googleId = externalClaims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            var givenName = externalClaims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName);
            var email = externalClaims.FirstOrDefault(c => c.Type == ClaimTypes.Email);
            if (googleId == null)
                throw new Exception("Could not extract the GoogleId");
            var idvalue = googleId.Value;
            var account = accountRepository.GetAccountWithGoogleId(idvalue);
            if (account == null)
            {
                account = new Account()
                {
                    Username = email.Value,
                    GoogleId = idvalue,
                    Name = givenName.Value,
                };
                accountRepository.addAccount(account);
            }
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, account.AccountId.ToString()),
                new Claim(ClaimTypes.Name, account.Name),
                new Claim(ClaimTypes.Role, account.Role.ToString()),
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return LocalRedirect(result.Properties?.Items["ReturnUrl"] ?? "/ ");
        }

        public async Task<IActionResult> Register()
        {
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Register([Bind("Role,Name,AccountId,Username,Password,GoogleId")] Account account)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(account);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(account);
        //}

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");
        }
    }
}