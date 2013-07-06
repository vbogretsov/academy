using System;

namespace Academy.Presentation.ViewModels
{
    public interface ITitledPostViewModel : IPostViewModel
    {
        string Title
        {
            get;
            set;
        }
    }
}
