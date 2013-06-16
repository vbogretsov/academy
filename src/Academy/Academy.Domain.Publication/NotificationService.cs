using System;
using System.Collections.Generic;
using System.Linq;
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
            user.Disciplines = disciplineStorage.Resolve(disciplineIds).ToList();
            userStorage.Update();
        }
    }
}
