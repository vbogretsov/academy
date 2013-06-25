using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Academy.Domain.Objects;

namespace Academy.Domain.DataAccess.Ef.Storages
{
    internal class EfNoteStorage : EfEntityStorage, INoteStorage
    {
        public EfNoteStorage(AcademyEntities academyEntities)
            :base(academyEntities)
        {
        }

        public void Add(Note note)
        {
            Add(note, Entities.Notes);
        }

        public void Remove(int noteId)
        {
            Remove(noteId, Entities.Notes);
        }

        public IEnumerable<Note> GetUserNotes(int userId)
        {
            return Entities.Notes.Where(x => x.UserId == userId);
        }
    }
}
