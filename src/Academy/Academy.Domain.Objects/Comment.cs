using System;
using System.ComponentModel.DataAnnotations;
using Academy.Domain.Objects.Enums;

namespace Academy.Domain.Objects
{
    public class Comment
    {
        [Key]
        public int CommentId
        {
            get;
            set;
        }

        [Required(ErrorMessage = "Comment text is required")]
        public string Text
        {
            get;
            set;
        }

        [Required(ErrorMessage = "Rating is required")]
        public Rating Rating
        {
            get;
            set;
        }

        public virtual User User
        {
            get;
            set;
        }

        public virtual Article Article
        {
            get;
            set;
        }
    }
}
