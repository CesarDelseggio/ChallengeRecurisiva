using ChallengeRecursiva.Business.Interfaces;
using ChallengeRecursiva.DataAccess.Data.Models;
using ChallengeRecursiva.DataAccess.Interfaces;
using ChallengeRecursiva.DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeRecursiva.Business.Services
{
    public class LogService : IService<Log>
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IRepository<Log> _repository;
        public LogService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = unitOfWork.LogRepository;
        }

        public async Task<int> Count()
        {
            return await _repository.Count();
        }

        public async Task<int> Count(ISpecificationRepository<Log> spec)
        {
            return await _repository.Count(spec);
        }

        public async Task<Log> Get(int id)
        {
            return await _repository.Get(id);
        }

        public async Task<List<Log>> GetAll()
        {
            return await _repository.GetAll().ToListAsync();
        }

        public async Task<List<Log>> GetAll(ISpecificationRepository<Log> spec)
        {
            return await _repository.GetAll(spec).ToListAsync();
        }

        public void Insert(Log entity)
        {
            _repository.Insert(entity);
        }

        public void Update(Log entity)
        {
            _repository.Update(entity);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public void DeleteAll()
        {
            _repository.DeleteAll();
        }
    }
}
