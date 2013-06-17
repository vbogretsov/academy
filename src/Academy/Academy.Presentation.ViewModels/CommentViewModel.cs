using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Academy.Validation;

namespace Academy.Presentation.ViewModels
{
    public class CommentViewModel : EntityViewModel
    {
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

        public DateTime CreationDate
        {
            get;
            set;
        }
    }
}
