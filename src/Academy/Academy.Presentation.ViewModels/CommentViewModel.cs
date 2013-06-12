using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Academy.Presentation.ViewModels
{
    public class CommentViewModel : EntityViewModel
    {
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
    }
}
