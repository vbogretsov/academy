using System;
using System.Collections.Generic;
using System.Linq;
using Academy.Domain.Objects;
using Academy.Utils.Trees;

namespace Academy.Domain.DataAccess.Ef.Storages
{
    internal class EfDisciplineStorage : EfEntityStorage, IDisciplineStorage
    {
        public EfDisciplineStorage(AcademyEntities academyEntities)
            :base(academyEntities)
        {
        }

        public IEnumerable<Discipline> Get()
        {
            return Entities.Disciplines;
        }

        public IEnumerable<Discipline> Get(IEnumerable<int> disciplineIds)
        {
            var treeHelper = GetHelper();
            var roots = treeHelper.GetRoots(disciplineIds.Select(Get));
            return GetAllChildren(roots).ToList();
        }

        public Discipline Get(int id)
        {
            //return Entities.Disciplines.SingleOrDefault(x => x.Id == id);
            return Get(id, Entities.Disciplines);
        }

        public Discipline Get(string name)
        {
            return Entities.Disciplines.SingleOrDefault(
                x => x.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase));
        }

        //public IEnumerable<Discipline> Resolve(IEnumerable<int> disciplineIds)
        //{
        //    return disciplineIds.Select(Get).Where(x => x != null);
        //}

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

        private void AddChildren(Entity node, List<Discipline> children)
        {
            var childDisciplines = Entities.Disciplines.Where(
                x => x.ParentId == node.Id).ToList();
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
                x => x.Id,
                x => x.ParentId != null ? x.ParentId.Value : 0);
        }
    }
}
