using System;
using Academy.Domain.Objects;

namespace Academy.Presentation.ViewModels.Mappers
{
    public static class DisciplineMapper
    {
        public static Discipline Map(DisciplineViewModel viewModel)
        {
            Discipline discipline = new Discipline();
            discipline.Id = viewModel.Id;
            discipline.Name = viewModel.Name;
            discipline.ParentId = viewModel.ParentId;
            return discipline;
        }

        public static DisciplineViewModel Map(Discipline discipline)
        {
            DisciplineViewModel viewModel = new DisciplineViewModel();
            viewModel.Id = discipline.Id;
            viewModel.ParentId = discipline.Parent != null
                ? discipline.Parent.Id
                : 0;
            viewModel.Name = discipline.Name;
            return viewModel;
        }
    }
}
