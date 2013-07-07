using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        [Required(ErrorMessage = "Question should have at least one discipline")]
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
