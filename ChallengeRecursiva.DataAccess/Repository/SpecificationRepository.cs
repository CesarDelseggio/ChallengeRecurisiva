using ChallengeRecursiva.DataAccess.Data.Models;
using ChallengeRecursiva.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ChallengeRecursiva.DataAccess.Repository
{
    public class SpecificationRepository<T> : ISpecificationRepository<T> where T : EntityBase
    {
        public Expression<Func<T, bool>> Criteria { get; private set; }

        public List<Expression<Func<T, object>>> Includes { get; private set; } = new List<Expression<Func<T, object>>>();

        public List<string> IncludeNames { get; private set; } = new List<string>();

        public int Skip { get; private set; } = 0;

        public int Take { get; private set; } = 10;

        protected void AddCriteria(Expression<Func<T,bool>> criteria)
        {
            Criteria = criteria;
        }

        protected void AddIncludes(List<Expression<Func<T,object>>> includes)
        {
            Includes = includes;
        }

        protected void AddIncludeNames(List<string> includeNames)
        {
            IncludeNames = includeNames;
        }

        protected void SetPageSize(int pageSize)
        {
            var oldPagecount = (Skip / Take) + 1;
            Take = pageSize;

            SetPageCount(oldPagecount);
        }

        protected void SetPageCount(int pageCount) 
        { 
            Skip = (Take * (pageCount - 1));
        }
    }
}
