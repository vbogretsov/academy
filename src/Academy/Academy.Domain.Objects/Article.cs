using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Academy.Domain.Objects
{
    public class Article : TitledPost, IByDisciplinesNotifiable
    {
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
