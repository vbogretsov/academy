using System;
using System.Collections.Generic;

namespace Academy.Domain.Objects
{
    public class Answer : Post
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

        public int QuestionId
        {
            get;
            set;
        }

        public virtual Question Question
        {
            get;
            set;
        }

        public virtual ICollection<AnswerNews> AnswerNewses
        {
            get;
            set;
        }
    }
}
