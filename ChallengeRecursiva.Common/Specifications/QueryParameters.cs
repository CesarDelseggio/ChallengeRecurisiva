using ChallengeRecursiva.Common.Interfaces;
using ChallengeRecursiva.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ChallengeRecursiva.Common.Specification
{
    public class QueryParameters<T> : IQueryParameters<T> where T : EntityBase
    {
        public Expression<Func<T, bool>> Where { get; set; }

        public List<Expression<Func<T, object>>> Includes { get; set; } = new List<Expression<Func<T, object>>>();

        public List<string> IncludeNames { get; set; } = new List<string>();

        public int Skip { get; private set; } = 0;

        public int Take { get; private set; } = 100;

        public void SetPage(int page, int pageSize)
        {
            Take = pageSize;

            Skip = (Take * (page - 1));
        }
    }
}
