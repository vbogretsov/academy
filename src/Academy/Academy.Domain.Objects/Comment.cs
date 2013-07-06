using System;
using System.Collections.Generic;

namespace Academy.Domain.Objects
{
    public class Comment : Post
    {
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
