using System;
using System.Web.Mvc;
using System.Web.UI;
using Academy.Presentation.ViewModels;
using Academy.Presentation.ViewModels.Mappers;
using Academy.Resources;
using Academy.Security;

namespace Academy.Presentation.Views.Controllers
{
    [Authorize]
    [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
    public class AccountController : AcademyController
    {
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel login, string returnUrl)
        {
            if (ModelState.IsValid && Login(login))
            {
                return RedirectToAction("Index", "Profile");
            }
            ModelState.AddModelError("", Localization.GetString("login.err.failed"));
            return RetryLogin(login);
        }

        [HttpGet]
        public ActionResult Logout()
        {
            AcademyContext.Account.Logout();
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public ActionResult RestorePassword()
        {
            // TODO: add password restoring.
            throw new NotImplementedException();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(RegistrationViewModel registration)
        {
            return ModelState.IsValid
                ? RegisterNewUser(registration)
                : RetryRegister(registration);
        }

        [HttpPost]
        [AllowAnonymous]
        public JsonResult CheckUserExists([Bind(Prefix = "Registration.Email")] string email)
        {
            return Json(!AcademyContext.Account.IsUserExists(email));
        }

        private bool Login(LoginViewModel login)
        {
            return AcademyContext.Account.Login(
                login.Email,
                login.Password,
                login.RememberMe);
        }

        private ActionResult RegisterNewUser(RegistrationViewModel registration)
        {
            var user = UserMapper.Map(registration);
            try
            {
                AcademyContext.Account.Register(user, registration.Password);
                AcademyContext.Account.Login(user.Email, registration.Password);
                return RedirectToAction("Index", "Profile");
            }
            catch (SecurityCreateUserException exception)
            {
                ModelState.AddModelError("", exception.Message);
                return RetryRegister(registration);
            }
        }

        private ActionResult RetryRegister(RegistrationViewModel registration)
        {
            return View("../Home/Index", new HomeViewModel
            {
                Login = new LoginViewModel(),
                Registration = registration
            });
        }

        private ActionResult RetryLogin(LoginViewModel login)
        {
            return View("../Home/Index", new HomeViewModel
            {
                Login = login,
                Registration = new RegistrationViewModel()
            });
        }
    }
}
