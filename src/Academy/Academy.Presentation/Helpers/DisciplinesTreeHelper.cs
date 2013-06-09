using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Academy.Domain.Objects;
using Academy.Presentation.Unity;
using Academy.Presentation.ViewModels;
using Academy.Utils;

namespace Academy.Presentation.Helpers
{
    public static class DisciplinesTreeHelper
    {
        //public static MvcHtmlString DisciplinesTreeFor(
        //    this HtmlHelper<Profile> html,
        //    Profile profile)
        //{
        //    var allDisciplines = ApplicationContainer.Instance.
        //        DisciplineStorage.GetDisciplines().ToList();
        //    var treeLoader = new TreeLoader<int, Discipline>(
        //        x => x.DisciplineId,
        //        x => x.Parent != null ? x.Parent.DisciplineId : 0);
        //    return html.CheckboxesTree(
        //        treeLoader.Load(allDisciplines),
        //        x => x.DisciplineId,
        //        x => x.Name,
        //        profile.Disciplines);
        //}

        public static MvcHtmlString DisciplinesTreeFor<TModel>(
            this HtmlHelper<TModel> html,
            string collectionName,
            IEnumerable<Discipline> selectedDisciplines = null)
        {
            var allDisciplines = ApplicationContainer.Instance.
                DisciplineStorage.GetDisciplines().ToList();
            var treeLoader = new TreeLoader<int, Discipline>(
                x => x.DisciplineId,
                x => x.Parent != null ? x.Parent.DisciplineId : 0);
            return html.CheckboxesTree(
                collectionName,
                treeLoader.Load(allDisciplines),
                x => x.DisciplineId,
                x => x.Name,
                selectedDisciplines);
        }
    }
}