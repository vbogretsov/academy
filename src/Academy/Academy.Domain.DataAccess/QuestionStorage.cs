using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Academy.Domain.Objects;

namespace Academy.Domain.DataAccess
{
    public abstract class QuestionStorage
    {
        public abstract void Add(Question question);
    }
}
