using ChallengeRecursiva.Business.Interfaces;
using ChallengeRecursiva.Business.Models.Logs;
using ChallengeRecursiva.Common.Interfaces;
using ChallengeRecursiva.Common.Models;
using ChallengeRecursiva.Common.Specification;
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
    public class LogService : ILogService
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

        public async Task<int> Count(IQueryParameters<Log> spec)
        {
            return await _repository.Count(spec);
        }

        public async Task<LogDetailDTO> Get(int id)
        {
            var result = await _repository.Get(id);

            return AutoMapper.Mapper.Map<LogDetailDTO>(result);
        }

        public async Task<List<LogDTO>> GetAll()
        {
            var result = await _repository.GetAll();

            return AutoMapper.Mapper.Map<List<LogDTO>>(result.ToListAsync());
        }

        public async Task<List<LogDTO>> GetAll(IQueryParameters<Log> spec)
        {
            var result = await _repository.GetAll(spec);

            return AutoMapper.Mapper.Map<List<LogDTO>>(result.ToListAsync());
        }

        public void Insert(LogEditDTO entity)
        {
            var entityModel = AutoMapper.Mapper.Map<Log>(entity);
            
            _repository.Insert(entityModel);
        }

        public void Update(LogEditDTO entity)
        {
            var entityModel = AutoMapper.Mapper.Map<Log>(entity);

            _repository.Update(entityModel);
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
