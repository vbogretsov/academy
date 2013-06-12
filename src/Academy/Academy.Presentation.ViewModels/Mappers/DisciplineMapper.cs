using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            viewModel.Name = discipline.Name;
            return viewModel;
        }
    }
}
