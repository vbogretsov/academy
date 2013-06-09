using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Web;
using Academy.Domain.Objects;
using Academy.Validation;

namespace Academy.Presentation.ViewModels
{
    public class ArticleViewModel
    {
        public ArticleViewModel()
        {
            Authors = new List<AuthorViewModel>();
            Disciplines = new List<Discipline>();
        }

        //[LocalizedDisplay("article.title")]
        //[LocalizedRequired("article.title.err.required")]
        public string Title
        {
            get;
            set;
        }

        //[LocalizedDisplay("article.description")]
        //[LocalizedRequired("article.description.err.required")]
        public string Description
        {
            get;
            set;
        }

        //[LocalizedDisplay("article.source")]
        //[LocalizedRequired("article.source.err.required")]
        public string Source
        {
            get;
            set;
        }

        [LocalizedDisplay("article.source")]
        [LocalizedRequired("article.source.err.required")]
        public HttpPostedFileBase File
        {
            get;
            set;
        }

        public ICollection<AuthorViewModel> Authors
        {
            get;
            set;
        }

        public ICollection<Discipline> Disciplines
        {
            get;
            set;
        }
    }
}