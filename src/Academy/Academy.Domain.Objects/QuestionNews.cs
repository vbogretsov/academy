using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
