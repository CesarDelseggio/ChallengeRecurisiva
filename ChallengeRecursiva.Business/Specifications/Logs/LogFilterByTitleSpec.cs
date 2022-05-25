using ChallengeRecursiva.Common.Interfaces;
using ChallengeRecursiva.Common.Models;
using ChallengeRecursiva.Common.Specification;
using ChallengeRecursiva.DataAccess.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ChallengeRecursiva.Business.Specifications.Logs
{
    public class LogFilterByTitleSpec : Specification<Log>
    {
        public LogFilterByTitleSpec(string title)
        {
            AddCriteria(x => x.Title.Contains(title));
        }
    }
}
