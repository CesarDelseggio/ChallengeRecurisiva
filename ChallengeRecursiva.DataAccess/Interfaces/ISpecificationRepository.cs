using ChallengeRecursiva.DataAccess.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ChallengeRecursiva.DataAccess.Interfaces
{
    public interface ISpecificationRepository<T> where T : EntityBase
    {
        Expression<Func<T,bool>> Criteria { get; }
        List<Expression<Func<T,object>>> Includes { get; }
        List<string> IncludeNames { get; }

        int Skip { get; }
        int Take { get; }
    }
}
