﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Academy.Validation;

namespace Academy.Domain.Objects
{
    public class User : Entity
    {
        [Required(ErrorMessage = "Email is requaried")]
        [StringLength(128)]
        [RegularExpression(Smtp.SmtpAddressPattern, ErrorMessage = "Email is invalid")]
        public string Email
        {
            get;
            set;
        }

        [Required(ErrorMessage = "First name is required")]
        [StringLength(64, MinimumLength = 2, ErrorMessage = "First name length should be between 2 nad 64")]
        public string FirstName
        {
            get;
            set;
        }

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(64, MinimumLength = 2, ErrorMessage = "Last name length should be between 2 nad 64")]
        public string LastName
        {
            get;
            set;
        }

        [Required(ErrorMessage = "University is required")]
        [StringLength(128)]
        public string University
        {
            get;
            set;
        }

        [Required(ErrorMessage = "Registration date should be specified")]
        public DateTime RegistrationDate
        {
            get;
            set;
        }

        [Required(ErrorMessage = "Last access date should be specified")]
        public DateTime LastAccessDate
        {
            get;
            set;
        }

        [Required(ErrorMessage = "Birth date is required")]
        public DateTime BirthDate
        {
            get;
            set;
        }

        public string PhotoFileName
        {
            get;
            set;
        }

        public virtual ICollection<Note> Notes
        {
            get;
            set;
        }

        public virtual ICollection<Question> Questions
        {
            get;
            set;
        }

        public virtual ICollection<Answer> Answers
        {
            get;
            set;
        }

        public virtual ICollection<Article> Articles
        {
            get;
            set;
        }

        public virtual ICollection<Comment> Comments
        {
            get;
            set;
        }

        public virtual ICollection<Discipline> Disciplines
        {
            get;
            set;
        }

        public virtual ICollection<ArticleNews> ArticleNewses
        {
            get;
            set;
        }

        public virtual ICollection<CommentNews> CommentNewses
        {
            get;
            set;
        }

        public virtual ICollection<QuestionNews> QuestionNewses
        {
            get;
            set;
        }

        public virtual ICollection<AnswerNews> AnswerNewses
        {
            get;
            set;
        }
    }
}
