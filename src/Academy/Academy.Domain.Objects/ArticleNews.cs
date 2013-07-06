using System;

namespace Academy.Domain.Objects
{
    public class ArticleNews : News
    {
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
