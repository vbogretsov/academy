using System;
using Academy.Domain.Objects;

namespace Academy.Presentation.ViewModels.Mappers
{
    public class PostMapper<TModel, TViewModel> : EntityMapper<TModel, TViewModel>
        where TModel : Post
        where TViewModel : IPostViewModel
    {
        public override TViewModel Map(TModel model)
        {
            var viewModel = base.Map(model);
            viewModel.Text = model.Text;
            viewModel.PostedDate = model.PostedDate;
            return viewModel;
        }

        public override TModel Map(TViewModel viewModel)
        {
            var model = base.Map(viewModel);
            model.Text = viewModel.Text;
            model.PostedDate = viewModel.PostedDate;
            return model;
        }
    }
}
