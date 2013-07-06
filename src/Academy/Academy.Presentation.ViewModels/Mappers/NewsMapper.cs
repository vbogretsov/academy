using System;
using Academy.Domain.Objects;

namespace Academy.Presentation.ViewModels.Mappers
{
    public class NewsMapper<TModel, TViewModel> : EntityMapper<TModel, TViewModel>
        where TModel : News
        where TViewModel : NewsViewModel
    {
        public override TViewModel Map(TModel model)
        {
            var viewModel = base.Map(model);
            viewModel.Read = model.Read;
            return viewModel;
        }

        public override TModel Map(TViewModel viewModel)
        {
            var model = base.Map(viewModel);
            model.Read = viewModel.Read;
            return model;
        }
    }
}
