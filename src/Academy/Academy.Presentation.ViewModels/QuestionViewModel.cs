using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Academy.Validation;

namespace Academy.Presentation.ViewModels
{
    public class QuestionViewModel : EntityViewModel
    {
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

        public UserViewModel Author
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
