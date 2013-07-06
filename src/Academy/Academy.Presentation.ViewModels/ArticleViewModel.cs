using System;
using System.Collections.Generic;
using Academy.Validation;

namespace Academy.Presentation.ViewModels
{
    public class ArticleViewModel : EntityViewModel, ITitledPostViewModel
    {
        public ArticleViewModel()
        {
            Authors = new List<AuthorViewModel>();
        }

        [LocalizedDisplay("article.title")]
        [LocalizedRequired("article.title.err.required")]
        public string Title
        {
            get;
            set;
        }

        [LocalizedDisplay("article.description")]
        [LocalizedRequired("article.description.err.required")]
        public string Text
        {
            get;
            set;
        }

        public DateTime PostedDate
        {
            get;
            set;
        }

        [LocalizedDisplay("article.source")]
        [LocalizedRequired("article.source.err.required")]
        public string Source
        {
            get;
            set;
        }

        public IEnumerable<AuthorViewModel> Authors
        {
            get;
            set;
        }

        [LocalizedRequired("article.disciplines.err.required")]
        public IEnumerable<DisciplineViewModel> Disciplines
        {
            get;
            set;
        }
    }
}
