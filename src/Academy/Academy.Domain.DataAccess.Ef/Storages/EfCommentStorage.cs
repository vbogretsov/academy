using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Domain.Objects;

namespace Academy.Domain.DataAccess.Ef.Storages
{
    internal class EfCommentStorage : ICommentStorage
    {
        private readonly AcademyEntities academyEntities;

        public EfCommentStorage(AcademyEntities academyEntities)
        {
            this.academyEntities = academyEntities;
        }

        public void Add(Comment comment)
        {
            academyEntities.Comments.Add(comment);
            academyEntities.SaveChanges();
        }

        public void Remove(Comment comment)
        {
            academyEntities.Comments.Remove(comment);
        }
    }
}
