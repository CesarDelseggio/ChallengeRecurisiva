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
            Database.EnsureCreated();
        }

        public DbSet<Log> Logs { get; set; }
        public DbSet<Partner> Partners { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seed data for test database is created.
            modelBuilder.Entity<Log>().HasData(
                new Log() { Id = 1, Date = DateTime.Now, Title = "First Log", Message = "Data for test services" },
                new Log() { Id = 2, Date = DateTime.Now, Title = "Second Log", Message = "This message is not valid" },
                new Log() { Id = 3, Date = DateTime.Now, Title = "Third Log", Message = "Data access faild" });
        }
    }
}
