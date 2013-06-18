using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Academy.Domain.Objects
{
    public class Question
    {
        public int QuestionId
        {
            get;
            set;
        }

        public string Text
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

        public ICollection<Answer> Answers
        {
            get;
            set;
        }

        public ICollection<Discipline> Disciplines
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
