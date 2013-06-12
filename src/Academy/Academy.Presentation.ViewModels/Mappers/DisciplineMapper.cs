using System;
using Academy.Domain.Objects;

namespace Academy.Presentation.ViewModels.Mappers
{
    public static class DisciplineMapper
    {
        public static Discipline Map(DisciplineViewModel viewModel)
        {
            Discipline discipline = new Discipline();
            discipline.DisciplineId = viewModel.Id;
            discipline.Name = viewModel.Name;
            return discipline;
        }

        public static DisciplineViewModel Map(Discipline discipline)
        {
            DisciplineViewModel viewModel = new DisciplineViewModel();
            viewModel.Id = discipline.DisciplineId;
            viewModel.ParentId = discipline.Parent != null
                ? discipline.Parent.DisciplineId
                : 0;
            viewModel.Name = discipline.Name;
            return viewModel;
        }
    }
}
