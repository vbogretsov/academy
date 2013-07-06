using System;

namespace Academy.Domain.Objects
{
    public class CommentNews : News
    {
        public virtual User User
        {
            get;
            set;
        }

        public virtual Comment Comment
        {
            get;
            set;
        }
    }
}
