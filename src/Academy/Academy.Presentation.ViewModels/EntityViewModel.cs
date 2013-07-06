using System;

namespace Academy.Presentation.ViewModels
{
    public abstract class EntityViewModel : IEntityViewModel
    {
        public int Id
        {
            get;
            set;
        }
    }
}
