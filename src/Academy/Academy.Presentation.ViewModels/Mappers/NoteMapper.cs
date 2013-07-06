using System;
using Academy.Domain.Objects;

namespace Academy.Presentation.ViewModels.Mappers
{
    public static class NoteMapper
    {
        private static readonly TitledPostMapper<Note, NoteViewModel> mapper =
            new TitledPostMapper<Note, NoteViewModel>();

        public static NoteViewModel Map(Note model)
        {
            var viewModel = mapper.Map(model);
            viewModel.UserId = model.UserId;
            return viewModel;
        }

        public static Note Map(NoteViewModel viewModel)
        {
            var model = mapper.Map(viewModel);
            model.UserId = viewModel.UserId;
            return model;
        }
    }
}
