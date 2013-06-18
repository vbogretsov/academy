using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Domain.Interface
{
    public interface IAcademyService
    {
        INoteService Notes
        {
            get;
        }

        IPublicationService Publications
        {
            get;
        }

        IQuestionService QuestionServices
        {
            get;
        }

        INotificationService Notifications
        {
            get;
        }
    }
}
