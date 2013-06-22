using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Academy.Domain.Objects.Enums;

namespace Academy.Domain.Objects
{
    public class Comment : Entity
    {
        //[Key]
        //public int CommentId
        //{
        //    get;
        //    set;
        //}

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

        [Required(ErrorMessage = "Creation date is required")]
        public DateTime PostedDate
        {
            get;
            set;
        }

        public int UserId
        {
            get;
            set;
        }

        public virtual User User
        {
            get;
            set;
        }

        public int ArticleId
        {
            get;
            set;
        }

        public virtual Article Article
        {
            get;
            set;
        }

        public virtual ICollection<CommentNews> CommentNewses
        {
            get;
            set;
        }
    }
}
