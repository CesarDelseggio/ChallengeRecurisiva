using ChallengeRecursiva.Common.Interfaces;
using ChallengeRecursiva.Common.Models;
using ChallengeRecursiva.DataAccess.Data.Models;
using ChallengeRecursiva.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeRecursiva.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<T> Get(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IQueryable<T>> GetAll()
        {
            return _context.Set<T>().AsQueryable();
        }

        public async Task<IQueryable<T>> GetAll(IQueryParameters<T> spec)
        {
            return ApplySpecification(spec, _context.Set<T>().AsQueryable());
        }

        public async Task<int> Count()
        {
            return await _context.Set<T>().CountAsync();
        }

        public async Task<int> Count(IQueryParameters<T> spec)
        {
            return await _context.Set<T>().CountAsync(spec.Where);
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

        private IQueryable<T> ApplySpecification(IQueryParameters<T> spec, IQueryable<T> query)
        {
            if (spec is null) return query;

            if (spec.Where != null) query = query.Where(spec.Where);

            foreach (var item in spec.Includes)
            {
                query.Include(item);
            }

            foreach (var item in spec.IncludeNames)
            {
                query.Include(item);
            }

            if(spec.OrderBy != null)
            {
                if(spec.OrderDescending)
                    query = query.OrderByDescending(spec.OrderBy);

                query = query.OrderBy(spec.OrderBy);
            }
            
            return query.Skip(spec.Skip)
                .Take(spec.Take);
        }
    }
}
