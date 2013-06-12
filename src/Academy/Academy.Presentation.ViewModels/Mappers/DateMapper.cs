using System;
using Academy.Presentation.ViewModels.Utils;

namespace Academy.Presentation.ViewModels.Mappers
{
    public static class DateMapper
    {
        public static DateTime Map(DateViewModel viewModel)
        {
            return new DateTime(viewModel.Year, viewModel.Month, viewModel.Day);
        }

        public static DateViewModel Map(DateTime dateTime)
        {
            return new DateViewModel(dateTime);
        }
    }
}
