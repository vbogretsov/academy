using System;
using System.ComponentModel.DataAnnotations;

namespace Academy.Domain.Objects
{
    public abstract class TitledPost : Post
    {
        [Required(ErrorMessage = "Title is required")]
        public string Title
        {
            get;
            set;
        }
    }
}
