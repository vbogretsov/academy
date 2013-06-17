using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Academy.Validation;

namespace Academy.Presentation.ViewModels
{
    public class CommentViewModel : EntityViewModel
    {
        public CommentViewModel()
        {
        }

        public CommentViewModel(ArticleViewModel parentArticle)
        {
            Article = parentArticle;
        }

        [LocalizedRequired("comment.text.err.required")]
        public string Text
        {
            get;
            set;
        }

        public AuthorViewModel Author
        {
            get;
            set;
        }

        public ArticleViewModel Article
        {
            get;
            set;
        }

        public DateTime CreationDate
        {
            get;
            set;
        }
    }
}
