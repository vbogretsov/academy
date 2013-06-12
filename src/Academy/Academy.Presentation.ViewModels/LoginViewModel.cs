using System;
using Academy.Validation;

namespace Academy.Presentation.ViewModels
{
    public class LoginViewModel
    {
        [LocalizedDisplay("login.email")]
        [LocalizedRequired("login.er.email.required")]
        [LocalizedEmail("login.er.email.invalid")]
        public string Email
        {
            get;
            set;
        }

        [LocalizedDisplay("login.pwd")]
        [LocalizedRequired("login.er.pwd.required")]
        public string Password
        {
            get;
            set;
        }

        [LocalizedDisplay("login.remember")]
        public bool RememberMe
        {
            get;
            set;
        }
    }
}
