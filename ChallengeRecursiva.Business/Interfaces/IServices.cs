using ChallengeRecursiva.DataAccess.Data.Models;
using ChallengeRecursiva.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeRecursiva.Business.Interfaces
{
    public interface IService<T> where T : EntityBase
    {
        Task<T> Get(int id);
        Task<List<T>> GetAll();
        Task<List<T>> GetAll(ISpecificationRepository<T> spec);
        Task<int> Count();
        Task<int> Count(ISpecificationRepository<T> spec);

        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
