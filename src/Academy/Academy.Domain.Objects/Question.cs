using System;
using System.Collections.Generic;

namespace Academy.Domain.Objects
{
    public class Question : TitledPost, IByDisciplinesNotifiable
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

        public virtual ICollection<Answer> Answers
        {
            get;
            set;
        }

        public virtual ICollection<Discipline> Disciplines
        {
            get;
            set;
        }

        public virtual ICollection<QuestionNews> QuestionNewses
        {
            get;
            set;
        }
    }
}
