using ChallengeRecursiva.Business.Interfaces;
using ChallengeRecursiva.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChallengeRecursiva.Business.Services
{
    public class SpecificationService<T> : ISpecificationService<T> where T : BaseDTO
    {
    }
}
