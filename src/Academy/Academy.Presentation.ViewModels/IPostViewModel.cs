using System;

namespace Academy.Presentation.ViewModels
{
    public interface IPostViewModel : IEntityViewModel
    {
        string Text
        {
            get;
            set;
        }

        DateTime PostedDate
        {
            get;
            set;
        }
    }
}
