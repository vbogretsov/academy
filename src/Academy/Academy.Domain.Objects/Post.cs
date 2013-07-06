using System;
using System.ComponentModel.DataAnnotations;

namespace Academy.Domain.Objects
{
    public abstract class Post : Entity
    {
        [Required(ErrorMessage = "Text is required")]
        public virtual string Text
        {
            get;
            set;
        }

        [Required(ErrorMessage = "Creation date is required")]
        public DateTime PostedDate
        {
            get;
            set;
        }
    }
}
