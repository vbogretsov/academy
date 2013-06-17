using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Academy.Domain.Objects
{
    public class Note
    {
        [Key]
        public int NoteId
        {
            get;
            set;
        }

        public string Title
        {
            get;
            set;
        }

        public string Text
        {
            get;
            set;
        }

        public virtual User User
        {
            get;
            set;
        }
    }
}
