using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Academy.Domain.Objects
{
    public class AnswerNews : News
    {
        //public int AnswerNewsId
        //{
        //    get;
        //    set;
        //}

        //public int UserId
        //{
        //    get;
        //    set;
        //}

        public virtual User User
        {
            get;
            set;
        }

        //public int AnswerId
        //{
        //    get;
        //    set;
        //}

        public virtual Answer Answer
        {
            get;
            set;
        }

        //public bool Read
        //{
        //    get;
        //    set;
        //}
    }
}
