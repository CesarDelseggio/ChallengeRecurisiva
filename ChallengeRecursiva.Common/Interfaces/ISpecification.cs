using ChallengeRecursiva.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ChallengeRecursiva.Common.Interfaces
{
    public interface ISpecification<T> where T : EntityBase
    {
        Expression<Func<T,bool>> Criteria { get; }
        List<Expression<Func<T,object>>> Includes { get; }
        List<string> IncludeNames { get; }

        int Skip { get; }
        int Take { get; }
    }
}
