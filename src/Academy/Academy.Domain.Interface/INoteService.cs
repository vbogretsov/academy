using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Domain.Objects;

namespace Academy.Domain.Interface
{
    public interface INoteService
    {
        void Add(Note note);

        void Remove(int noteId);

        //TODO: add paging
        IEnumerable<Note> GetNotes(int userId);
    }
}
