using ChallengeRecursiva.Business.Interfaces;
using ChallengeRecursiva.Business.Models.Parteners;
using ChallengeRecursiva.Common.Specification;
using ChallengeRecursiva.DataAccess.Data.Models;
using ChallengeRecursiva.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<double> Exercise2()
        {
            var query = new QueryParameters<Partner>();
            query.Where = x => x.Team.ToUpper() == "RACING";

            var partners = await _unitOfWork.PartnerRepository.GetAll(query);

            return partners.Average(x=>x.Age);
        }

        public async Task<List<PartnerDto>> Exercise3()
        {
            //Get Queryable for repository.
            var partners = await _unitOfWork.PartnerRepository.GetAll();

            var result = from p in partners
                         where p.CivilStatus.ToUpper() == "CASADO" &&
                               p.StudiesLevel.ToUpper() == "UNIVERSITARIO"
                         orderby p.Age
                         select new PartnerDto {
                             Name = p.Name,
                             Age = p.Age,
                             Team = p.Team,
                             CivilStatus = p.CivilStatus,
                             StudiesLevel = p.StudiesLevel
                         };
            
            return result.Take(100).ToList();
        }

        public async Task<List<string>> Exercise4()
        {
            var paterns = await _unitOfWork.PartnerRepository.GetAll();

            var query = from p in paterns 
                        where p.Team.ToUpper() == "RIVER"
                        group p by p.Name into partnersGroup orderby partnersGroup.Count()
                        select partnersGroup.Key;

            return query.Take(5).ToList();
        }

        public async Task<List<PartnerAgregateDto>> Exercise5()
        {
            var paterns = await _unitOfWork.PartnerRepository.GetAll();

            var query = from p in paterns
                        group p
                        by p.Team into partnersGroup
                        orderby partnersGroup.Count()
                        select new PartnerAgregateDto()
                        { 
                            Team = partnersGroup.Key,
                            PartnerCount = partnersGroup.Count(),
                            AverageAge = partnersGroup.Average(x=>x.Age),
                            MaxAge = partnersGroup.Max(x=>x.Age),
                            MinAge = partnersGroup.Min(x => x.Age)
                        };

            return query.ToList();
        }
    }
}
