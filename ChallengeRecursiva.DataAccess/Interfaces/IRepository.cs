using ChallengeRecursiva.DataAccess.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChallengeRecursiva.DataAccess.Interfaces
{
    public interface IRepository<T> where T : EntityBase
    {
        T Get(int id);
        List<T> GetAll(ISpecificationRepository<T> spec);

        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);
        void DeleteAll();
    }
}
