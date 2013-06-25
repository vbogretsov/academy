using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Academy.Domain.DataAccess;
using Academy.Domain.Interface;
using Academy.Domain.Objects;

namespace Academy.Domain.Services
{
    public class NoteService : INoteService
    {
        private readonly IDataContext context;

        public NoteService(IDataContext context)
        {
            this.context = context;
        }

        public void Add(Note note)
        {
            note.PostedDate = DateTime.Now;
            context.NoteStorage.Add(note);
        }

        public void Remove(int noteId)
        {
            context.NoteStorage.Remove(noteId);
        }

        // TODO: add paging
        public IEnumerable<Note> GetNotes(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
