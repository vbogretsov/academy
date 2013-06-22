using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Academy.Domain.Objects
{
    public class CommentNews : News
    {
        //public int CommentNewsId
        //{
        //    get;
        //    set;
        //}

        //public int UserId
        //{
        //    get;
        //    set;
        //}

        public virtual User User
        {
            get;
            set;
        }

        //public int CommentId
        //{
        //    get;
        //    set;
        //}

        public virtual Comment Comment
        {
            get;
            set;
        }

        //public bool Read
        //{
        //    get;
        //    set;
        //}
    }
}
