using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Academy.Presentation.ViewModels
{
    public class QuestionSearchViewModel
    {
        public string Title
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
