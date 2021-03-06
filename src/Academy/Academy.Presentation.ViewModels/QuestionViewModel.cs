﻿using System;
using System.Collections.Generic;
using Academy.Validation;

namespace Academy.Presentation.ViewModels
{
    public class QuestionViewModel : EntityViewModel, ITitledPostViewModel
    {
        [LocalizedDisplay("question.title")]
        [LocalizedRequired("question.title.err.required")]
        public string Title
        {
            get;
            set;
        }

        [LocalizedDisplay("question.text")]
        [LocalizedRequired("question.text.err.required")]
        public string Text
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

        public DateTime PostedDate
        {
            get;
            set;
        }

        [LocalizedRequired("question.disciplines.err.required")]
        //[LocalizedCollectionLength(1, "question.disciplines.err.required")]
        public IEnumerable<DisciplineViewModel> Disciplines
        {
            get;
            set;
        }
    }
}
