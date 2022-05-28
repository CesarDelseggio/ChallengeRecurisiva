using ChallengeRecursiva.Business.Interfaces;
using ChallengeRecursiva.DataAccess.Data.Models;
using ChallengeRecursiva.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeRecursiva.Business.Services
{
    public class ReportPartnerServices : IReportPartnerServices
    {
        private UnitOfWork _unitOfWork;
        public ReportPartnerServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Exercise1()
        {
            return await _unitOfWork.PartnerRepository.Count();
        }

        public Task<int> Exercise2()
        {
            throw new NotImplementedException();
        }

        public Task<List<Partner>> Exercise3()
        {
            throw new NotImplementedException();
        }

        public Task<List<string>> Exercise4()
        {
            throw new NotImplementedException();
        }

        public Task<List<Partner>> Exercise5()
        {
            throw new NotImplementedException();
        }
    }
}
