using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Academy.Domain.Objects;

namespace Academy.Domain.DataAccess
{
    public abstract class AnswerStorage
    {
        public abstract void Add(Answer answer);
    }
}
