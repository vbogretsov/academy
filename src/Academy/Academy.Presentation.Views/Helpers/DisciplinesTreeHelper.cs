using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Academy.Presentation.ViewModels;
using Academy.Presentation.ViewModels.Mappers;
using Academy.Presentation.Views.Unity;
using Academy.Utils;

namespace Academy.Presentation.Views.Helpers
{
    public static class DisciplinesTreeHelper
    {
        public static MvcHtmlString DisciplinesTreeFor<TModel>(
            this HtmlHelper<TModel> html,
            string collectionName,
            IEnumerable<DisciplineViewModel> selectedDisciplines = null)
        {
            var allDisciplines = ApplicationContainer.Instance.
                DisciplineStorage.GetDisciplines().Select(DisciplineMapper.Map).ToList();
            var treeLoader = new TreeLoader<int, DisciplineViewModel>(
                x => x.Id,
                x => x.ParentId);
            return html.CheckboxesTree(
                collectionName,
                treeLoader.Load(allDisciplines),
                x => x.Id,
                x => x.Name,
                selectedDisciplines);
        }
    }
}