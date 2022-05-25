using ChallengeRecursiva.DataAccess.Data.Models;
using ChallengeRecursiva.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChallengeRecursiva.DataAccess.Repository
{
    public class UnitOfWork
    {
        private AppDbContext _context;

        public UnitOfWork(AppDbContext contex)
        {
            _context = contex;
        }

        private IRepository<Log> _logRepository;
        public IRepository<Log> LogRepository
        {
            get {
                if (_logRepository == null)
                    _logRepository = new Repository<Log>(_context);

                return _logRepository; 
            }
        }

    }
}
