﻿using System;
using System.Collections.Generic;
using System.Web;
using Academy.Validation;
using Academy.Presentation.ViewModels.Utils;

namespace Academy.Presentation.ViewModels
{
    public class UserViewModel : EntityViewModel
    {
        private HttpPostedFileBase photoFile;

        //public UserViewModel()
        //{
        //    //Disciplines = new List<DisciplineViewModel>();
        //    //Articles = new List<ArticleViewModel>();
        //    //Comments = new List<CommentViewModel>();
        //}

        [LocalizedDisplay("user.email")]
        [LocalizedRequired("user.email.err.required")]
        [LocalizedEmail("user.email.err.invalid")]
        public string Email
        {
            get;
            set;
        }

        [LocalizedDisplay("user.firstname")]
        [LocalizedRequired("user.firstname.err.requiered")]
        public string FirstName
        {
            get;
            set;
        }

        [LocalizedDisplay("user.lastname")]
        [LocalizedRequired("user.lastname.err.required")]
        public string LastName
        {
            get;
            set;
        }

        [LocalizedDisplay("user.university")]
        [LocalizedRequired("user.university.err.required")]
        public string University
        {
            get;
            set;
        }

        [LocalizedDisplay("user.birthdate")]
        [LocalizedRequired("user.birthdate.err.required")]
        public DateViewModel BirthDate
        {
            get;
            set;
        }

        public string PhotoFileName
        {
            get;
            set;
        }

        [LocalizedDisplay("Photo")]
        public HttpPostedFileBase PhotoFile
        {
            get
            {
                return photoFile;
            }
            set
            {
                photoFile = value;
                if (photoFile != null)
                {
                    PhotoFileName = photoFile.FileName;
                }
            }
        }

        public IEnumerable<DisciplineViewModel> Disciplines
        {
            get;
            set;
        }

        public PageDataViewModel<ArticleViewModel> ArticlesPage
        {
            get;
            set;
        }

        public PageDataViewModel<NoteViewModel> NotesPage
        {
            get;
            set;
        }

        public PageDataViewModel<QuestionViewModel> QuestionsPage
        {
            get;
            set;
        }
    }
}
