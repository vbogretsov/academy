using System;

namespace Academy.Domain.Objects
{
    public class QuestionNews : News
    {
        public virtual User User
        {
            get;
            set;
        }

        public virtual Question Question
        {
            get;
            set;
        }
    }
}
