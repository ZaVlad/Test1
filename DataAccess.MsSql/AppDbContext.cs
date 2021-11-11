using Entities.Models;
using Infrastructure.Interfaces.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasData(new List<Person>()
            {
                new Person(){Id= 1,DateOfBirth = new DateTime(2004,9,28),Married = false,Name = "Vlad",Phone = "0500653293",Salary = 500.23M },
                new Person(){Id= 2,DateOfBirth = new DateTime(2003,12,28),Married = false,Name = "Xenia",Phone = "0669925380",Salary = 499.23M },
                new Person(){Id= 3,DateOfBirth = DateTime.Now,Married = true,Name = "Ivan",Phone = "0523673293",Salary = 12.23M }
            });
        }
        private void ModelsConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasKey(s => s.Id);
            modelBuilder.Entity<Person>().Property(s => s.Phone).IsRequired().HasMaxLength(10);
            modelBuilder.Entity<Person>().Property(s => s.Name).IsRequired();
            modelBuilder.Entity<Person>().Property(s => s.Married).IsRequired();
            modelBuilder.Entity<Person>().Property(s => s.Salary).IsRequired();
            modelBuilder.Entity<Person>().Property(s => s.DateOfBirth).IsRequired();
        }
    }
}
