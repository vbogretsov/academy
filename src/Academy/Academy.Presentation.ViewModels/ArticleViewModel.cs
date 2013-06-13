using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using Academy.Validation;

namespace Academy.Presentation.ViewModels
{
    public class ArticleViewModel : EntityViewModel
    {
        private HttpPostedFileBase articleFile;

        public ArticleViewModel()
        {
            Authors = new List<AuthorViewModel>();
            Disciplines = new List<DisciplineViewModel>();
            Comments = new List<CommentViewModel>();
        }

        [LocalizedDisplay("article.title")]
        //[LocalizedRequired("article.title.err.required")]
        [Required(ErrorMessage = "Article title is required")]
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
        public HttpPostedFileBase ArticleFile
        {
            get
            {
                return articleFile;
            }
            set
            {
                articleFile = value;
                if(articleFile != null)
                {
                    Source = articleFile.FileName;
                }
            }
        }

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

        public IEnumerable<DisciplineViewModel> Disciplines
        {
            get;
            set;
        }

        public IEnumerable<CommentViewModel> Comments
        {
            get;
            set;
        }
    }
}
