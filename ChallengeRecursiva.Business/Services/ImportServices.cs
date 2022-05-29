using ChallengeRecursiva.Business.Interfaces;
using ChallengeRecursiva.DataAccess;
using ChallengeRecursiva.DataAccess.Data.Models;
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
            var connection = _configuration.GetConnectionString("DefaultConnectionStrings");
            var fullPath = Path.Combine(filePath, fileName);

            if (File.Exists(fullPath))
                await RemoveOldData();

            try
            {
                var fileLines = File.ReadAllLines(fullPath, Encoding.UTF7);

                if (fileLines.Length == 0) return false;

                var table = new DataTable();

                //Add column names;
                table.Columns.Add("Id", typeof(int));
                table.Columns.Add("Name");
                table.Columns.Add("Age",typeof(int));
                table.Columns.Add("Team");
                table.Columns.Add("CivilStatus");
                table.Columns.Add("StudiesLevel");

                string line;
                //ReadFile.
                for (int i = 0; i < fileLines.Length; i++)
                {
                    //Add Id property
                    line = $"{i+1};" + fileLines[i];
                    table.Rows.Add(line.Split(';'));
                }
                
                var sqlBulk = new SqlBulkCopy(connection);
                sqlBulk.DestinationTableName = "Partners";
                await sqlBulk.WriteToServerAsync(table);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private async Task<int> RemoveOldData()
        {
            var sqlText = "Delete From Partners";

            try
            {
                using (var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnectionStrings")))
                {
                    conn.Open();
                    var command = new SqlCommand(sqlText, conn);
                    return await command.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
            {
                throw;
            }   
        }
    }
}
