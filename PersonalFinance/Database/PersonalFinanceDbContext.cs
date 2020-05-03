using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonalFinance.Domain.Entities;
using PersonalFinance.Domain.ValueObjects;

namespace PersonalFinance.Database
{
    public class PersonalFinanceDbContext : DbContext
    {
        //public DbSet<Account> Accounts { get; set; }
        //public DbSet<Transaction> Transactions { get; set; }
        //public DbSet<Month> MonthSnapshots { get; set; }

        public DbSet<Category> Categories { get; set; }
        
        public PersonalFinanceDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>(x =>
            {
                x.HasKey(e => e.Id);
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=pf.db");
        }
    }
}
