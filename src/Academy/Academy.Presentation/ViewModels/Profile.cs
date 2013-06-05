using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Web;
using Academy.Domain.Objects;
using Academy.Presentation.Utils;
using Academy.Validation;
using Academy.Validation;

namespace Academy.Presentation.ViewModels
{
    public class Profile
    {
        public Profile()
        {
        }

        public Profile(User user)
        {
            Email = user.Email;
            FirstName = user.FirstName;
            LastName = user.LastName;
            University = user.University;
            BirthDate = new Date(user.BirthDate);
            PhotoFileName = user.PhotoFileName;
        }

        [LocalizedDisplay("")]
        [StringLength(128)]
        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"[a-zA-Z0-9]*@[a-z]*\.(com|ru)", ErrorMessage = "Email is invalid")]
        public string Email
        {
            get;
            set;
        }

        [Display(Name = "First name")]
        [Required(ErrorMessage = "First name is required")]
        [StringLength(64)]
        public string FirstName
        {
            get;
            set;
        }

        [Display(Name = "Last name")]
        [Required(ErrorMessage = "Last name is required")]
        [StringLength(64)]
        public string LastName
        {
            get;
            set;
        }

        [Display(Name = "University")]
        [Required(ErrorMessage = "University is required")]
        [StringLength(128)]
        public string University
        {
            get;
            set;
        }

        [Display(Name = "Birth date")]
        [Required(ErrorMessage = "Birth date is required")]
        public Date BirthDate
        {
            get;
            set;
        }

        [Display(Name = "Photo file")]
        public HttpPostedFileBase PostedPhoto
        {
            get;
            set;
        }

        public string PhotoFileName
        {
            get;
            set;
        }
    }
}