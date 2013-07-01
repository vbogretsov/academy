using System;
using System.Linq;
using Academy.Domain.DataAccess;

namespace Academy.Presentation.ViewModels.Mappers
{
    public static class PageDataMapper
    {
        public static PageViewModel<TViewModel> Map<TModel, TViewModel>(
            IPageData<TModel> model,
            Func<TModel, TViewModel> map)
        {
            var viewModel = new PageViewModel<TViewModel>();
            viewModel.Items = model.Data.Select(map).ToList();
            viewModel.PageNumber = model.PageNumber;
            viewModel.PagesCount = model.PagesCount;
            viewModel.PageSize = model.PageSize;
            return viewModel;
        }
    }
}
