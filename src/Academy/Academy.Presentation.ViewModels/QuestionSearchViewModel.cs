using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Academy.Validation;

namespace Academy.Presentation.ViewModels
{
    public class QuestionSearchViewModel
    {
        [LocalizedDisplay("question.search.keyword")]
        public string Keyword
        {
            get;
            set;
        }

        public IEnumerable<DisciplineViewModel> Disciplines
        {
            get;
            set;
        }
    }
}
