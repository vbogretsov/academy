using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.UI;
using Academy.Domain.DataAccess;
using Academy.Domain.Objects;
using Academy.Presentation.Filter;
using Academy.Presentation.Unity;
using Academy.Presentation.ViewModels;
using Academy.Security;

namespace Academy.Presentation.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
    [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
    public class AccountController : Controller
    {
        private const string UnknownPasswordError =
            "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

        private static readonly IDictionary<MembershipCreateStatus, string> passwrodErrors;

        private readonly UserStorage userStorage;

        private readonly AccountManager accountManager;

        private readonly RoleManager roleManager;

        static AccountController()
        {
            passwrodErrors = new Dictionary<MembershipCreateStatus, string>();
            passwrodErrors.Add(
                MembershipCreateStatus.DuplicateUserName,
                "User name already exists. Please enter a different user name.");
            passwrodErrors.Add(
                MembershipCreateStatus.DuplicateEmail,
                "A user name for that e-mail address already exists. Please enter a different e-mail address.");
            passwrodErrors.Add(
                MembershipCreateStatus.InvalidPassword,
                "The password provided is invalid. Please enter a valid password value.");
            passwrodErrors.Add(
                MembershipCreateStatus.InvalidEmail,
                "The e-mail address provided is invalid. Please check the value and try again.");
            passwrodErrors.Add(
                MembershipCreateStatus.InvalidAnswer,
                "The password retrieval answer provided is invalid. Please check the value and try again.");
            passwrodErrors.Add(
                MembershipCreateStatus.InvalidQuestion,
                "The password retrieval question provided is invalid. Please check the value and try again.");
            passwrodErrors.Add(
                MembershipCreateStatus.InvalidUserName,
                "The user name provided is invalid. Please check the value and try again.");
            passwrodErrors.Add(
                MembershipCreateStatus.ProviderError,
                "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.");
            passwrodErrors.Add(
                MembershipCreateStatus.UserRejected,
                "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.");
        }

        public AccountController()
        {
            userStorage = ApplicationContainer.Instance
                .Resolve<IStorageFactory>().CreateUserStorage();
            accountManager = ApplicationContainer.Instance
                .Resolve<AccountManager>();
            roleManager = ApplicationContainer.Instance
                .Resolve<RoleManager>();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(Login login, string returnUrl)
        {
            if (ModelState.IsValid &&
                accountManager.Login(login.Email, login.Password, login.RememberMe))
            {
                return RedirectToAction("Index", "Profile");
            }
            ModelState.AddModelError("", "The user name or password provided is incorrect.");
            return RetryLogin(login);
        }

        public ActionResult Logout()
        {
            accountManager.Logout();
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public ActionResult RestorePassword()
        {
            throw new NotImplementedException();
        }

        //[HttpPost]
        [AllowAnonymous]
        public ActionResult Register(Registration registration)
        {
            if (ModelState.IsValid)
            {
                Register(registration.MapToUser(), registration.MapToLogin());
                return RedirectToAction("Index", "Profile");
            }
            return RetryRegister(registration);
        }

        [HttpPost]
        [AllowAnonymous]
        public JsonResult CheckUserExists([Bind(Prefix = "Registration.Email")] string email)
        {
            bool userExists = userStorage.Contains(email);
            return Json(!userExists);
        }

        private void Register(User user, Login login)
        {
            CreateUser(user);
            try
            {
                CreateLogin(login);
            }
            catch (MembershipCreateUserException exception)
            {
                ModelState.AddModelError("", ErrorCodeToString(exception.StatusCode));
                userStorage.Delete(user);
            }
        }

        private void CreateUser(User user)
        {
            userStorage.Add(user);
        }

        private void CreateLogin(Login login)
        {
            roleManager.AddUserToRole(login.Email, "User");
            accountManager.CreateAccount(login.Email, login.Password);
            accountManager.Login(login.Email, login.Password);
        }

        private ActionResult RetryRegister(Registration registration)
        {
            return View("../Home/Index", new HomeViewModel
            {
                Login = new Login(),
                Registration = registration
            });
        }

        private ActionResult RetryLogin(Login login)
        {
            return View("../Home/Index", new HomeViewModel
            {
                Login = login,
                Registration = new Registration()
            });
        }

        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            return passwrodErrors.ContainsKey(createStatus)
                       ? passwrodErrors[createStatus]
                       : UnknownPasswordError;
        }
    }
}
