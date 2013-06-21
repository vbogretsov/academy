using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Academy.Domain.Objects;

namespace Academy.Domain.DataAccess.Ef.Storages
{
    internal class EfNoteStorage : INoteStorage
    {
        private readonly AcademyEntities academyEntities;

        public EfNoteStorage(AcademyEntities academyEntities)
        {
            this.academyEntities = academyEntities;
        }

        public void Add(Note note)
        {
            academyEntities.Notes.Add(note);
            academyEntities.SaveChanges();
        }

        public void Remove(Note note)
        {
            academyEntities.Notes.Attach(note);
            academyEntities.Notes.Remove(note);
            academyEntities.SaveChanges();
        }

        public IEnumerable<Note> GetUserNotes(User user)
        {
            return user.Notes;
        }
    }
}
