using System;
using Academy.Domain.Objects;
using Academy.Presentation.Utils;
using Academy.Validation;

namespace Academy.Presentation.ViewModels
{
    public class Registration
    {
        public Registration()
        {
            BirthDate = new Date();
        }

        public Login MapToLogin()
        {
            Login login = new Login();
            login.Email = Email;
            login.Password = Password;
            login.RememberMe = false;
            return login;
        }

        public User MapToUser()
        {
            User user = new User();
            user.Email = Email;
            user.FirstName = FirstName;
            user.LastName = LastName;
            user.RegistrationDate = DateTime.Now;
            user.LastAccessDate = DateTime.Now;
            user.University = University;
            user.BirthDate = BirthDate.ToDateTime();
            return user;
        }

        [LocalizedDisplay("home.reg.email")]
        [LocalizedRequired("home.reg.er.email.required")]
        [LocalizedRegularExpression(@"[a-zA-Z0-9]*@[a-z]*\.(com|ru)", "home.reg.er.email.invalid")]
        [LocalizedRemote("CheckUserExists", "Account", "POST", "home.reg.er.email.exists")]
        public string Email
        {
            get;
            set;
        }

        [LocalizedDisplay("home.reg.pwd")]
        [LocalizedRequired("home.reg.er.pwd.required")]
        [LocalizedStringLength(6, 256, "home.reg.er.pwd.length")]
        public string Password
        {
            get;
            set;
        }

        [LocalizedDisplay("home.reg.pwdconf")]
        [LocalizedRequired("home.reg.er.pwdconf.required")]
        [LocalizedCompare("Password", "home.reg.er.pwdconf.notmatch")]
        public string PasswordConfirmation
        {
            get;
            set;
        }

        [LocalizedDisplay("home.reg.fname")]
        [LocalizedRequired("home.reg.er.fname.required")]
        public string FirstName
        {
            get;
            set;
        }

        [LocalizedDisplay("home.reg.lname")]
        [LocalizedRequired("home.reg.er.lname.required")]
        public string LastName
        {
            get;
            set;
        }

        [LocalizedDisplay("home.reg.univercity")]
        [LocalizedRequired("home.reg.er.university.required")]
        public string University
        {
            get;
            set;
        }

        [LocalizedDisplay("home.reg.bidthdate")]
        public Date BirthDate
        {
            get;
            set;
        }
    }
}