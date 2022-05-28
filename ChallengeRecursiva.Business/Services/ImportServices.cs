using ChallengeRecursiva.Business.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeRecursiva.Business.Services
{
    public class ImportServices : IImportServices
    {
        //Used for read connection string
        private readonly IConfiguration _configuration;
        private const string defaultFileName = "socios.csv";

        public ImportServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> ImportPartners(string filePath, string fileName = defaultFileName)
        {
            throw new NotImplementedException();
        }
    }
}
