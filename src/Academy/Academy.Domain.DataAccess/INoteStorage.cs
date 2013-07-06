using System;
using Academy.Domain.Objects;

namespace Academy.Domain.DataAccess
{
    public interface INoteStorage
    {
        void Add(Note note);

        void Remove(int noteId);

        IPageData<Note> GetUserNotes(int userId, int page, int size);
    }
}
