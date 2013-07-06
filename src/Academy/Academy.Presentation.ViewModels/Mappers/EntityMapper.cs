using System;
using Academy.Domain.Objects;

namespace Academy.Presentation.ViewModels.Mappers
{
    public abstract class EntityMapper<TModel, TViewModel>
        where TModel : Entity
        where TViewModel : IEntityViewModel
    {
        public virtual TModel Map(TViewModel viewModel)
        {
            var model = Activator.CreateInstance<TModel>();
            model.Id = viewModel.Id;
            return model;
        }

        public virtual TViewModel Map(TModel model)
        {
            var viewModel = Activator.CreateInstance<TViewModel>();
            viewModel.Id = model.Id;
            return viewModel;
        }
    }
}
