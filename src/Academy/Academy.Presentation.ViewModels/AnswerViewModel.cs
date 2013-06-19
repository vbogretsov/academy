using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Academy.Validation;

namespace Academy.Presentation.ViewModels
{
    public class AnswerViewModel : EntityViewModel
    {
        [LocalizedRequired("answer.text.err.required")]
        public string Text
        {
            get;
            set;
        }

        public int AuthorId
        {
            get;
            set;
        }

        public AuthorViewModel Author
        {
            get;
            set;
        }

        public int QuestionId
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
