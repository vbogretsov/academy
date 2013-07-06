using System;

namespace Academy.Domain.Objects
{
    public class AnswerNews : News
    {
        public virtual User User
        {
            get;
            set;
        }
        public virtual Answer Answer
        {
            get;
            set;
        }
    }
}
