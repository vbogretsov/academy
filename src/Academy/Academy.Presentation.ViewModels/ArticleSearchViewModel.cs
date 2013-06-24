using System;
using System.Collections.Generic;
using Academy.Validation;

namespace Academy.Presentation.ViewModels
{
    public class ArticleSearchViewModel
    {
        [LocalizedDisplay("article.search.title")]
        public string Title
        {
            get;
            set;
        }

        [LocalizedDisplay("article.search.description")]
        public string Description
        {
            get;
            set;
        }

        [LocalizedDisplay("article.search.author")]
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
