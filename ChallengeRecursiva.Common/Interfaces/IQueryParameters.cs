using ChallengeRecursiva.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ChallengeRecursiva.Common.Interfaces
{
    public interface IQueryParameters<T> where T : EntityBase
    {
        Expression<Func<T,bool>> Where { get; set; }
        List<Expression<Func<T,object>>> Includes { get; set; }
        List<string> IncludeNames { get; set; }

        Expression<Func<T, object>> OrderBy { get; set; }
        bool OrderDescending { get; set; }

        int Skip { get; }
        int Take { get; }
    }
}
