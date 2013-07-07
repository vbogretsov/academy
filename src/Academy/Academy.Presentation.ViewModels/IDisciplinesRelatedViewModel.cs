using System;
using System.Collections.Generic;

namespace Academy.Presentation.ViewModels
{
    public interface IDisciplinesRelatedViewModel
    {
        IEnumerable<DisciplineViewModel> Disciplines
        {
            get;
        }
    }
}
