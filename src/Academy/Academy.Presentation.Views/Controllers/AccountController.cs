using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.UI;
using Academy.Domain.DataAccess;
using Academy.Domain.Objects;
using Academy.Domain.Services;
using Academy.Presentation.ViewModels;
using Academy.Presentation.ViewModels.Mappers;
using Academy.Presentation.Views.Unity;
using Academy.Security;

namespace Academy.Presentation.Views.Controllers
{
    [Authorize]
    //[InitializeSimpleMembership]
    [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
    public class AccountController : Controller
    {
        //private readonly UserStorage userStorage;

        //private readonly AccountManager accountManager;

        //private readonly RoleManager roleManager;

        //private readonly AccountService accountService;

        private readonly ApplicationContainer container;

        public AccountController()
        {
            //userStorage = ApplicationContainer.Instance.UserStorage;
            //accountManager = ApplicationContainer.Instance
            //    .Resolve<AccountManager>();
            //roleManager = ApplicationContainer.Instance
            //    .Resolve<RoleManager>();
            container = ApplicationContainer.Instance;
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel login, string returnUrl)
        {
            if (ModelState.IsValid && Login(login))
            {
                return RedirectToAction("Index", "Profile");
            }
            ModelState.AddModelError("", "The user name or password provided is incorrect.");
            return RetryLogin(login);
        }

        public ActionResult Logout()
        {
            //accountManager.Logout();
            container.Service.Account.Logout();
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public ActionResult RestorePassword()
        {
            throw new NotImplementedException();
        }

        //[HttpPost]
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
            return Json(!container.UserStorage.Contains(email));
        }

        private bool Login(LoginViewModel login)
        {
            return container.Service.Account.Login(
                login.Email,
                login.Password,
                login.RememberMe);
        }

        private ActionResult RegisterNewUser(RegistrationViewModel registration)
        {
            var user = UserMapper.Map(registration);
            try
            {
                container.Service.Account.Register(user, registration.Password);
                container.Service.Account.Login(user.Email, registration.Password);
                return RedirectToAction("Index", "Profile");
                //CreateLogin(registration.Email, registration.Password);
            }
            catch (SecurityCreateUserException exception)
            {
                ModelState.AddModelError("", exception.Message);
                return RetryRegister(registration);
                //userStorage.Delete(user);
            }
        }

        //private void CreateUser(User user)
        //{
        //    userStorage.Add(user);
        //}

        //private void CreateLogin(string email, string password)
        //{
        //    roleManager.AddUserToRole(email, "User");
        //    accountManager.CreateAccount(email, password);
        //    accountManager.Login(email, password);
        //}

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
