using ChallengeRecursiva.Business.Models;
using ChallengeRecursiva.Business.Models.Logs;
using ChallengeRecursiva.Common.Interfaces;
using ChallengeRecursiva.Common.Models;
using ChallengeRecursiva.DataAccess.Data.Models;
using ChallengeRecursiva.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeRecursiva.Business.Interfaces
{
    public interface ILogService
    {
        Task<LogDetailDTO> Get(int id);
        Task<List<LogDTO>> GetAll();
        Task<List<LogDTO>> GetAll(ISpecification<Log> spec);
        Task<int> Count();
        Task<int> Count(ISpecification<Log> spec);

        void Insert(LogEditDTO entity);
        void Update(LogEditDTO entity);
        void Delete(int id);
    }
}
