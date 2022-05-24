using ChallengeRecursiva.DataAccess.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace ChallengeRecursiva.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options)
        {

        }

        public DbSet<Log> Logs { get; set; }
    }
}
