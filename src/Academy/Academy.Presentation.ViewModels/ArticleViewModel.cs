using System;
using System.Collections.Generic;
using Academy.Validation;

namespace Academy.Presentation.ViewModels
{
    public class ArticleViewModel : EntityViewModel
    {
        public ArticleViewModel()
        {
            Authors = new List<AuthorViewModel>();
            Disciplines = new List<DisciplineViewModel>();
            Comments = new List<CommentViewModel>();
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
        public string Description
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
        [LocalizedCollectionLength(1, "article.disciplines.err.required")]
        public IEnumerable<DisciplineViewModel> Disciplines
        {
            get;
            set;
        }

        //TODO: add paging
        public IEnumerable<CommentViewModel> Comments
        {
            get;
            set;
        }
    }
}
