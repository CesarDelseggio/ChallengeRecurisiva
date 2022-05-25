using ChallengeRecursiva.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ChallengeRecursiva.DataAccess.Data.Models
{
    public class Log : EntityBase
    {
        public DateTime Date { get; set; }
        [Required]
        public string Title { get; set; }
        public string Message { get; set; }
    }
}
