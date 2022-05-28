using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeRecursiva.Business.Interfaces
{
    public interface IImportServices
    {
        Task<bool> ImportPartners(string filePath, string fileName);
    }
}
