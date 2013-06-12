using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Academy.Presentation.ViewModels.Utils;
using Academy.Validation;

namespace Academy.Presentation.ViewModels
{
    public class RegistrationViewModel
    {
        [LocalizedDisplay("registration.email")]
        [LocalizedRequired("registration.er.email.required")]
        [LocalizedEmail("registration.er.email.invalid")]
        [LocalizedRemote("CheckUserExists", "Account", "POST", "registration.er.email.exists")]
        public string Email
        {
            get;
            set;
        }

        [LocalizedDisplay("registration.pwd")]
        [LocalizedRequired("registration.er.pwd.required")]
        [LocalizedStringLength(6, 256, "registration.er.pwd.length")]
        public string Password
        {
            get;
            set;
        }

        [LocalizedDisplay("registration.pwdconf")]
        [LocalizedRequired("registration.er.pwdconf.required")]
        [LocalizedCompare("Password", "registration.er.pwdconf.notmatch")]
        public string PasswordConfirmation
        {
            get;
            set;
        }

        [LocalizedDisplay("registration.fname")]
        [LocalizedRequired("registration.er.fname.required")]
        public string FirstName
        {
            get;
            set;
        }

        [LocalizedDisplay("registration.lname")]
        [LocalizedRequired("registration.er.lname.required")]
        public string LastName
        {
            get;
            set;
        }

        [LocalizedDisplay("registration.univercity")]
        [LocalizedRequired("registration.er.university.required")]
        public string University
        {
            get;
            set;
        }

        [LocalizedDisplay("registration.bidthdate")]
        public DateViewModel BirthDate
        {
            get;
            set;
        }
    }
}
