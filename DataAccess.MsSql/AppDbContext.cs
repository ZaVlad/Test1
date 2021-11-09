using Entities.Models;
using Infrastructure.Interfaces.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DataAccess.MsSql
{
    public class AppDbContext : DbContext,IDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options)
        {
        }
        public DbSet<Person> Person { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ModelsConfiguration(modelBuilder);
        }

        private void ModelsConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasKey(s => s.Id);
            modelBuilder.Entity<Person>().Property(s => s.Phone).HasMaxLength(10);
            modelBuilder.Entity<Person>().Property(s => s.Name).IsRequired();
            modelBuilder.Entity<Person>().Property(s => s.Married).IsRequired();
            modelBuilder.Entity<Person>().Property(s => s.Salary).IsRequired();
            modelBuilder.Entity<Person>().Property(s => s.DateOfBirth).IsRequired();
        }
    }
}
