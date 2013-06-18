using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Academy.Domain.Objects
{
    public class ArticleNews
    {
        public int ArticleNewsId
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

        public bool Read
        {
            get;
            set;
        }
    }
}
