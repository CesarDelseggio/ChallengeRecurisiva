using System;
using System.Collections.Generic;
using System.Text;

namespace ChallengeRecursiva.Business.Interfaces
{
    public interface IService<T> where T : class
    {
        T Get(int id);
        List<T> GetAll(ISpecificationService<T> spec);

        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
