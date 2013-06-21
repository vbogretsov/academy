using System;
using System.Collections.Generic;
using Academy.Domain.Objects;

namespace Academy.Domain.DataAccess
{
    public interface INoteStorage
    {
        void Add(Note note);

        void Remove(Note note);

        IEnumerable<Note> GetUserNotes(User user);
    }
}
