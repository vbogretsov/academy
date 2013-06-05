using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Academy.Domain.Objects
{
    public class Discipline
    {
        [Key]
        public int DisciplineId
        {
            get;
            set;
        }

        public string Name
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
    }
}
