﻿using ChallengeRecursiva.Common.Interfaces;
using ChallengeRecursiva.Common.Models;
using ChallengeRecursiva.DataAccess.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeRecursiva.DataAccess.Interfaces
{
    public interface IRepository<T> where T : EntityBase
    {
        Task<T> Get(int id);
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(ISpecification<T> spec);
        Task<int> Count();
        Task<int> Count(ISpecification<T> spec);

        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);
        void DeleteAll();
    }
}
