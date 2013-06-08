using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Academy.Domain.DataAccess;

namespace Academy.Domain.Services
{
    public class AcademyService
    {
        public AcademyService(IStorageFactory storageFactory)
        {
            var disciplineStorage = storageFactory.CreateDisciplineStorage();
            var userStorage = storageFactory.CreateUserStorage();
            Notification = new NotificationService(disciplineStorage, userStorage);
        }

        public NotificationService Notification
        {
            get;
            private set;
        }
    }
}
