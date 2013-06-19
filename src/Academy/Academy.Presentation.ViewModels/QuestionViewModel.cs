using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Academy.Validation;

namespace Academy.Presentation.ViewModels
{
    public class QuestionViewModel : EntityViewModel
    {
        [LocalizedDisplay("question.title")]
        [LocalizedRequired("question.title.err.required")]
        public string Title
        {
            get;
            set;
        }

        [LocalizedDisplay("question.text")]
        [LocalizedRequired("question.text.err.required")]
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

        public DateTime PostedDate
        {
            get;
            set;
        }

        public IEnumerable<DisciplineViewModel> Disciplines
        {
            get;
            set;
        }

        //TODO: add paging
        public IEnumerable<AnswerViewModel> Answers
        {
            get;
            set;
        }
    }
}
