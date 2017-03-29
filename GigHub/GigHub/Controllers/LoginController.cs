using GigHub.Authentication;
using GigHub.Models;
using GigHub.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Web;
using System.Web.Mvc;

namespace GigHub.Controllers
{
    public class LoginController : Controller
    {
        private Context _context { get; set; }

        public LoginController()
        {
            _context = new Context();
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(RegisterViewModel model)
        {
            if(ModelState.IsValid)
            {
                var user = new User()
                {
                    Name = model.Name,
                    UserName = model.Email,
                    Email = model.Email
                };
                var userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var result = userManager.Create(user, model.Password);
                if (result.Succeeded)
                {
                    HttpContext.GetOwinContext().Get<ApplicationSignInManager>().SignInAsync(user, isPersistent: false, rememberBrowser: false);
                    return RedirectToAction("Index", "Home");
                }
            }

            return View(model);
        }

        // GET: Login
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var owinContext = HttpContext.GetOwinContext();
                var userManager = owinContext.GetUserManager<ApplicationUserManager>();
                var signInManager = owinContext.Get<ApplicationSignInManager>();
                var signIn = signInManager.PasswordSignIn(model.UserName, model.Password, model.RememberMe, false);
                switch(signIn)
                {
                    case SignInStatus.Failure:
                    case SignInStatus.LockedOut:
                    case SignInStatus.RequiresVerification:
                        break;
                    case SignInStatus.Success:
                        return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError("", "Invalid username or password");
            return View("Index", model);
        }

        [HttpPost]
        public ActionResult Logout()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }
    }
}