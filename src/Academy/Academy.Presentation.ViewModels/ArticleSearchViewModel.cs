using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Academy.Presentation.ViewModels
{
    public class ArticleSearchViewModel
    {
        public string Title
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public string Author
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
