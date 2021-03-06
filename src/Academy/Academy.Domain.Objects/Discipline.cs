﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Academy.Domain.Objects
{
    public class Discipline : Entity
    {
        public override string ToString()
        {
            return Name;
        }

        public string Name
        {
            get;
            set;
        }

        public int? ParentId
        {
            get;
            set;
        }

        public virtual Discipline Parent
        {
            get;
            set;
        }

        public virtual ICollection<Article> Articles
        {
            get;
            set;
        }

        public virtual ICollection<User> Users
        {
            get;
            set;
        }

        public virtual ICollection<Question> Questions
        {
            get;
            set;
        }
    }
}
