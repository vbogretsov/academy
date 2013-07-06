using System;
using Academy.Validation;

namespace Academy.Presentation.ViewModels
{
    public class CommentViewModel : EntityViewModel, IPostViewModel
    {
        [LocalizedDisplay("comment.text")]
        [LocalizedRequired("comment.text.err.required")]
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

        public int AuthorId
        {
            get;
            set;
        }

        public AuthorViewModel Author
        {
            get;
            set;
        }

        public int ArticleId
        {
            get;
            set;
        }

        public ArticleViewModel Article
        {
            get;
            set;
        }
    }
}
