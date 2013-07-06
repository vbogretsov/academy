using System;
using Academy.Domain.Objects;

namespace Academy.Presentation.ViewModels.Mappers
{
    public class TitledPostMapper<TModel, TViewModel> : PostMapper<TModel, TViewModel>
        where TModel : TitledPost
        where TViewModel : ITitledPostViewModel
    {
        public override TViewModel Map(TModel model)
        {
            var viewModel = base.Map(model);
            viewModel.Title = model.Title;
            return viewModel;
        }

        public override TModel Map(TViewModel viewModel)
        {
            var model = base.Map(viewModel);
            model.Title = viewModel.Title;
            return model;
        }
    }
}
