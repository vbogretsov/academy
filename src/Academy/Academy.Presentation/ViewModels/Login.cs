using System;
using Academy.Validation;

namespace Academy.Presentation.ViewModels
{
    public class Login
    {
        [LocalizedDisplay("home.login.email")]
        [LocalizedRequired("home.login.er.email.required")]
        [LocalizedRegularExpression(@"[a-z]*@[a-z]*\.(com)|(ru)", "home.login.er.email.invalid")]
        public string Email
        {
            get;
            set;
        }

        [LocalizedDisplay("home.login.pwd")]
        [LocalizedRequired("home.login.er.pwd.required")]
        public string Password
        {
            get;
            set;
        }

        [LocalizedDisplay("home.login.remember")]
        public bool RememberMe
        {
            get;
            set;
        }
    }
}