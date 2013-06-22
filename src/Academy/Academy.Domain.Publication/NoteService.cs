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
        public NoteService(IDataContext context)
        {
            
        }

        public void Add(Note note)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Note> GetNotes(User user)
        {
            throw new NotImplementedException();
        }
    }
}
