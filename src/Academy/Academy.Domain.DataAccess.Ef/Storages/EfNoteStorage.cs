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

        public IPageData<Note> GetUserNotes(int userId, int page, int size)
        {
            var query = GetUserNotesQuery(userId);
            return GetPage(query, page, size, GetUserNotesCount(userId));
        }

        private IEnumerable<Note> GetUserNotesQuery(int userId)
        {
            return from note in Entities.Notes
                    where note.UserId == userId
                    orderby note.PostedDate descending
                select note;
        }

        private int GetUserNotesCount(int userId)
        {
            return GetUserNotesQuery(userId).Count();
        }
    }
}
