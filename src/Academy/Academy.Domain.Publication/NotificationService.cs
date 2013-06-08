using System;
using System.Collections.Generic;
using Academy.Domain.DataAccess;
using Academy.Domain.Objects;

namespace Academy.Domain.Services
{
    public class NotificationService
    {
        private readonly DisciplineStorage disciplineStorage;
        private readonly UserStorage userStorage;

        public NotificationService(
            DisciplineStorage disciplineStorage,
            UserStorage userStorage)
        {
            this.disciplineStorage = disciplineStorage;
            this.userStorage = userStorage;
        }

        public void AssigneDisciplines(User user, IEnumerable<int> disciplineIds)
        {
            user.Disciplines.Clear();
            foreach (int disciplineId in disciplineIds)
            {
                var discipline = disciplineStorage.Get(disciplineId);
                if (discipline != null)
                {
                    user.Disciplines.Add(discipline);
                }
            }
            userStorage.Update();
        }
    }
}
