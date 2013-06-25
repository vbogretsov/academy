using System;
using Academy.Validation;

namespace Academy.Presentation.ViewModels
{
    public class NoteViewModel : EntityViewModel
    {
        public int UserId
        {
            get;
            set;
        }

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

        public DateTime PostedDate
        {
            get;
            set;
        }
    }
}
