using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Academy.Domain.Objects;

namespace Academy.Presentation.ViewModels.Mappers
{
    public static class NoteMapper
    {
        public static NoteViewModel Map(Note note)
        {
            NoteViewModel viewModel = new NoteViewModel();
            viewModel.Id = note.NoteId;
            viewModel.Title = note.Title;
            viewModel.Text = note.Text;
            return viewModel;
        }

        public static Note Map(NoteViewModel viewModel)
        {
            Note note = new Note();
            note.NoteId = viewModel.Id;
            note.Title = viewModel.Title;
            note.Text = viewModel.Text;
            return note;
        }
    }
}
