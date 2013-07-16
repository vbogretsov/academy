using System;
using System.Collections.Generic;

namespace Academy.Presentation.ViewModels
{
    public class QuestionSearchResultViewModel
    {
        public IEnumerable<QuestionViewModel> Questions
        {
            get;
            set;
        }
    }
}
