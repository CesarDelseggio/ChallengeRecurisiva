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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Log>().HasData(
                new Log() { Date = DateTime.Now, Title = "First Log", Message = "Data for test services" },
                new Log() { Date = DateTime.Now, Title = "Second Log", Message = "This message is not valid" },
                new Log() { Date = DateTime.Now, Title = "Third Log", Message = "Data access faild" });
        }
    }
}
