using System;

namespace Academy.Domain.Objects
{
    public class Answer
    {
        public int AnswerId
        {
            get;
            set;
        }

        public string Text
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

        public DateTime PostedDate
        {
            get;
            set;
        }
    }
}
