﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Academy.Domain.DataAccess.Ef.Search;
using Academy.Domain.Objects;
using Academy.Domain.Search;

namespace Academy.Domain.DataAccess.Ef.Storages
{
    internal class EfQuestionStorage : EfEntityStorage, IQuestionStorage
    {
        public EfQuestionStorage(AcademyEntities academyEntities)
            :base(academyEntities)
        {
        }

        public Question Get(int questionId)
        {
            return Get(questionId, Entities.Questions);
        }

        public void Add(Question question)
        {
            Add(question, Entities.Questions);
        }

        public IEnumerable<Question> GetUserQuestions(int userId)
        {
            return Entities.Questions.Where(x => x.UserId == userId);
        }

        public IEnumerable<Question> FindQuestions(QuestionSearchCriteria criteria)
        {
            var predicates = QuestionPredicateBuilder.Build(criteria);
            return Entities.Questions.Where(
                question => PredicatesComputer.Compute(predicates, question));
        }
    }
}
