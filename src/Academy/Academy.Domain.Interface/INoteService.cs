using System;
using Academy.Domain.DataAccess;
using Academy.Domain.Objects;

namespace Academy.Domain.Interface
{
    public interface INoteService
    {
        void Add(Note note);

        void Remove(int noteId);

        IPageData<Note> GetUserNotes(int userId, int page, int size);
    }
}
