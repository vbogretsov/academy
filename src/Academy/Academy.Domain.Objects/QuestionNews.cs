using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Academy.Domain.Objects
{
    public class QuestionNews
    {
        public int QuestionNewsId
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

        public bool Read
        {
            get;
            set;
        }
    }
}
