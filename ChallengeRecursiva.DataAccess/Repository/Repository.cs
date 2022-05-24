using ChallengeRecursiva.DataAccess.Data.Models;
using ChallengeRecursiva.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChallengeRecursiva.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        private readonly AppDbContext _context; 
        
        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public T Get(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public List<T> GetAll(ISpecificationRepository<T> spec)
        {
            var query = ApplySpecification(spec, _context.Set<T>().AsQueryable());

            return query.ToList();
        }

        public void Insert(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
        public void Delete(int id)
        {
            var entity = _context.Set<T>().Find(id);
            _context.Set<T>().Remove(entity);
        }

        public void DeleteAll()
        {
            var query = _context.Set<T>().AsQueryable();
            _context.Set<T>().RemoveRange(query);
        }

        private IQueryable<T> ApplySpecification(ISpecificationRepository<T> spec, IQueryable<T> query)
        {
            if (spec.Criteria != null) query = query.Where(spec.Criteria);

            foreach (var item in spec.Includes)
            {
                query.Include(item);
            }

            foreach (var item in spec.IncludeNames)
            {
                query.Include(item);
            }

            return query.Skip(spec.Skip)
                .Take(spec.Take);
        }
    }
}
