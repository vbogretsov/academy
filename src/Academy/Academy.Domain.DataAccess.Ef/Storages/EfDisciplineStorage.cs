using System;
using System.Collections.Generic;
using System.Linq;
using Academy.Domain.Objects;
using Academy.Utils.Trees;

namespace Academy.Domain.DataAccess.Ef.Storages
{
    internal class EfDisciplineStorage : IDisciplineStorage
    {
        private readonly AcademyEntities academyEntities;

        public EfDisciplineStorage(AcademyEntities academyEntities)
        {
            this.academyEntities = academyEntities;
        }

        public IEnumerable<Discipline> Get()
        {
            return academyEntities.Disciplines;
        }

        public IEnumerable<Discipline> Get(IEnumerable<Discipline> disciplines)
        {
            var treeHelper = GetHelper();
            var roots = treeHelper.GetRoots(disciplines);
            return GetAllChildren(roots);
        }

        public Discipline Get(int id)
        {
            return academyEntities.Disciplines.SingleOrDefault(
                x => x.DisciplineId == id);
        }

        public Discipline Get(string name)
        {
            return academyEntities.Disciplines.SingleOrDefault(
                x => x.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase));
        }

        public IEnumerable<Discipline> Resolve(IEnumerable<int> disciplineIds)
        {
            return disciplineIds.Select(Get).Where(x => x != null);
        }

        private IEnumerable<Discipline> GetAllChildren(IEnumerable<Discipline> roots)
        {
            List<Discipline> childs = new List<Discipline>();
            foreach (var root in roots)
            {
                childs.AddRange(GetAllChildren(root));
            }
            return childs;
        }

        private IEnumerable<Discipline> GetAllChildren(Discipline root)
        {
            var children = new List<Discipline> {root};
            AddChildren(root, children);
            return children;
        }

        private void AddChildren(Discipline node, List<Discipline> children)
        {
            var childDisciplines = academyEntities.Disciplines.Where(
                x => x.ParentId == node.DisciplineId).ToList();
            if (childDisciplines.Count > 0)
            {
                children.AddRange(childDisciplines);
                foreach (var childDiscipline in childDisciplines)
                {
                    AddChildren(childDiscipline, children);
                }
            }
        }

        private static TreeHelper<int, Discipline> GetHelper()
        {
            return new TreeHelper<int, Discipline>(
                x => x.DisciplineId,
                x => x.ParentId != null ? x.ParentId.Value : 0);
        }
    }
}
