using ChallengeRecursiva.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChallengeRecursiva.Business.Models.Logs
{
    public class LogEditDTO : EntityBase
    {
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
    }
}
