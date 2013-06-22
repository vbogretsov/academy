using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Academy.Domain.Objects
{
    public class Article : Entity, IByDisciplinesNotifiable
    {
        //[Key]
        //public int ArticleId
        //{
        //    get;
        //    set;
        //}

        [Required(ErrorMessage = "Article title is required")]
        public string Title
        {
            get;
            set;
        }

        [Required(ErrorMessage = "Article description is required")]
        public string Description
        {
            get;
            set;
        }

        [Required(ErrorMessage = "Source file name is required")]
        public string Source
        {
            get;
            set;
        }

        public virtual ICollection<User> Authors
        {
            get;
            set;
        }

        [Required(ErrorMessage = "Article should have at least one discipline")]
        public virtual ICollection<Discipline> Disciplines
        {
            get;
            set;
        }

        public virtual ICollection<Comment> Comments
        {
            get;
            set;
        }

        public virtual ICollection<ArticleNews> ArticleNewses
        {
            get;
            set;
        }
    }
}
