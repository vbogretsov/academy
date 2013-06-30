using System;

namespace Academy.Domain.Interface.Facade
{
    public interface IAcademyService :
        IAccountService,
        IAdministrationService,
        INoteService,
        IQuestionService,
        IPublicationService,
        ISearchService,
        INotificationService,
        IFileService
    {
    }
}
