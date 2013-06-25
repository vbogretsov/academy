using System;
using Academy.Domain.Objects;

namespace Academy.Presentation.ViewModels.Mappers
{
    public static class NoteMapper
    {
        public static NoteViewModel Map(Note note)
        {
            NoteViewModel viewModel = new NoteViewModel();
            viewModel.Id = note.Id;
            viewModel.UserId = note.UserId;
            viewModel.Title = note.Title;
            viewModel.Text = note.Text;
            viewModel.PostedDate = note.PostedDate;
            return viewModel;
        }

        public static Note Map(NoteViewModel viewModel)
        {
            Note note = new Note();
            note.Id = viewModel.Id;
            note.UserId = viewModel.UserId;
            note.Title = viewModel.Title;
            note.Text = viewModel.Text;
            note.PostedDate = viewModel.PostedDate;
            return note;
        }
    }
}
