using System;
using System.Collections.Generic;
using Academy.Domain.Objects;

namespace Academy.Domain.DataAccess
{
    public interface INoteStorage
    {
        void Add(Note note);

        void Remove(int noteId);

        IEnumerable<Note> GetUserNotes(int userId);
    }
}
