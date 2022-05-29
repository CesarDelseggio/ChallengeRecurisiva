using System;
using System.Collections.Generic;
using System.Text;

namespace ChallengeRecursiva.Business.Models.Parteners
{
    public class PartnerAgregateDto
    {
        public string Team { get; set; }
        public int PartnerCount { get; set; }
        public double AverageAge { get; set; }
        public int MaxAge { get; set; }
        public int MinAge { get; set; }
    }
}
