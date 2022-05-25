using ChallengeRecursiva.Common.Interfaces;
using ChallengeRecursiva.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ChallengeRecursiva.Common.Specification
{
    public class Specification<T> : ISpecification<T> where T : EntityBase
    {
        public Expression<Func<T, bool>> Criteria { get; private set; }

        public List<Expression<Func<T, object>>> Includes { get; private set; } = new List<Expression<Func<T, object>>>();

        public List<string> IncludeNames { get; private set; } = new List<string>();

        public int Skip { get; private set; } = 0;

        public int Take { get; private set; } = 100;

        protected void AddCriteria(Expression<Func<T,bool>> criteria)
        {
            Criteria = criteria;
        }

        protected void AddIncludes(Expression<Func<T,object>> includes)
        {
            Includes.Add(includes);
        }

        protected void AddIncludeNames(string includeName)
        {
            IncludeNames.Add(includeName);
        }

        protected void SetPagination(int page, int pageSize)
        {
            Take = pageSize;

            Skip = (Take * (page - 1));
        }
    }
}
