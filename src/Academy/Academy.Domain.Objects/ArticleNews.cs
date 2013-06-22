using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
