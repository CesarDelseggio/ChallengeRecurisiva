using ChallengeRecursiva.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChallengeRecursiva.Business.Models.Logs
{
    public class LogDTO : EntityBase
    {
        public DateTime Date { get; set; }
        public string Title { get; set; }
    }
}
