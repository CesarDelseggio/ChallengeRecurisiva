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
    public class LogFilterByTitleSpec : QueryParameters<Log>
    {
        public LogFilterByTitleSpec(string title)
        {
            Where = x => x.Title.Contains(title);
        }
    }
}
