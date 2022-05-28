using ChallengeRecursiva.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChallengeRecursiva.DataAccess.Data.Models
{
    public class Partner : EntityBase
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Team { get; set; }
        public string CivilStatus { get; set; }
        public string StudiesLevel { get; set; }
    }
}
