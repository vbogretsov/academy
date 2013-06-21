using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Academy.Validation;

namespace Academy.Presentation.ViewModels
{
    public class NoteViewModel : EntityViewModel
    {
        [LocalizedDisplay("note.title")]
        [LocalizedRequired("note.title.err.required")]
        public string Title
        {
            get;
            set;
        }

        [LocalizedDisplay("note.text")]
        [LocalizedRequired("note.text.err.required")]
        public string Text
        {
            get;
            set;
        }
    }
}
