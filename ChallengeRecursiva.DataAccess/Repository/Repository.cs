using ChallengeRecursiva.DataAccess.Data.Models;
using ChallengeRecursiva.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChallengeRecursiva.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {

    }
}
