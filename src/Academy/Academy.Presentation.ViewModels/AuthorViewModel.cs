using System;
using Academy.Validation;

namespace Academy.Presentation.ViewModels
{
    public class AuthorViewModel : EntityViewModel
    {
        [LocalizedDisplay("author.email")]
        [LocalizedRequired("author.email.err.required")]
        [LocalizedEmail("author.email.err.invalid")]
        public string Email
        {
            get;
            set;
        }

        [LocalizedDisplay("author.firstname")]
        [LocalizedRequired("author.firstname.err.required")]
        
        public string FirstName
        {
            get;
            set;
        }

        [LocalizedDisplay("author.lastname")]
        [LocalizedRequired("author.lastname.err.required")]
        public string LastName
        {
            get;
            set;
        }
    }
}
